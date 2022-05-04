using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.w9wen.dotnet.Template.Web.Endpoints.Employee;
using Swashbuckle.AspNetCore.Annotations;
using w9wen.dotnet.Template.Core.Constants;
using w9wen.dotnet.Template.Core.Entities;
using w9wen.dotnet.Template.Infrastructure.Data;

namespace w9wen.dotnet.Template.Web.Endpoints.Employee
{
  public class Create : EndpointBaseAsync
    .WithRequest<CreateEmployeeRequest>
    .WithActionResult<EmployeeDto>
  {
    private readonly AppUserManager _appUserManager;
    private readonly IMapper _mapper;

    public Create(AppUserManager appUserManager,
                  IMapper mapper)
    {
      _appUserManager = appUserManager;
      _mapper = mapper;
    }

    [HttpPost(EmployeeListRequest.Route)]
    [SwaggerOperation(
        Summary = "Create a new employee",
        Description = "Create a new employee",
        OperationId = "Employee.Create",
        Tags = new[] { "EmployeeEndpoints" })
    ]
    public override async Task<ActionResult<EmployeeDto>> HandleAsync(CreateEmployeeRequest request, CancellationToken cancellationToken = default)
    {
      if (string.IsNullOrEmpty(request.UserName))
      {
        return BadRequest("User name could not be null or empty");
      }

      // if (request.AppRoleList == null || request.AppRoleList.Count < 1)
      // {
      //   return BadRequest("You should choose a role at lease!");
      // }

      if (await _appUserManager.Users.AnyAsync(x => x.UserName.ToLower().Equals(request.UserName.ToLower())))
      {
        return BadRequest("User name already taken");
      }

      var appUserItem = this._mapper.Map<AppUserEntity>(request);

      var createResult = await _appUserManager.CreateAsync(appUserItem, EmployeeConstants.DEFAULT_PASSWORD);

      if (!createResult.Succeeded) return BadRequest(createResult.Errors);

      // var addToRoleResult = await _appUserManager.AddToRolesAsync(appUserItem, request.AppRoleList);

      // if (!addToRoleResult.Succeeded) return BadRequest(addToRoleResult.Errors);

      return _mapper.Map<EmployeeDto>(appUserItem);

    }
  }
}