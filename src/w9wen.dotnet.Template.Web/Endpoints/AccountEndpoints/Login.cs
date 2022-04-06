using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using w9wen.dotnet.Template.Core.Entities;
using w9wen.dotnet.Template.Infrastructure.Data;
using w9wen.dotnet.Template.Web.Interfaces;

namespace w9wen.dotnet.Template.Web.Endpoints.AccountEndpoints
{
  public class Login : EndpointBaseAsync
    .WithRequest<LoginRequest>
    .WithActionResult<LoginResponse>
  {
    private readonly AppUserManager _appUserManager;
    private readonly SignInManager<AppUserEntity> _signInMamager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public Login(AppUserManager appUserManager,
                 SignInManager<AppUserEntity> signInMamager,
                 ITokenService tokenService,
                 IMapper mapper)
    {
      _appUserManager = appUserManager;
      _signInMamager = signInMamager;
      _tokenService = tokenService;
      _mapper = mapper;
    }

    [HttpPost(LoginRequest.Route)]
    [SwaggerOperation(
        Summary = "Login to system",
        Description = "Login to system",
        OperationId = "Account.Login",
        Tags = new[] { "AccountEndpoints" })
    ]
    public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
      if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
      {
        return BadRequest();
      }

      var appUser = await _appUserManager.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower());
      if (appUser == null) return Unauthorized("Invalid User Name");

      var result = await _signInMamager
        .CheckPasswordSignInAsync(appUser, request.Password, false);

      if (!result.Succeeded) return Unauthorized();

      var response = new LoginResponse
      {
        UserName = appUser.UserName,
        Token = await _tokenService.CreateToken(appUser),
        KnownAs = appUser.KnownAs,
        Gender = appUser.Gender,
      };

      return Ok(response);
    }
  }
}