using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.w9wen.dotnet.Template.Web.Endpoints.Employee;
using Swashbuckle.AspNetCore.Annotations;
using w9wen.dotnet.Template.Infrastructure.Data;

namespace w9wen.dotnet.Template.Web.Endpoints.Employee
{
  public class Update : EndpointBaseAsync
    .WithRequest<EmployeeDto>
    .WithoutResult
  {
    #region Fields

    private readonly AppUserManager _appUserManager;
    private readonly IMapper _mapper;

    #endregion Fields

    #region Constructor

    public Update(AppUserManager appUserManager, IMapper mapper)
    {
      _appUserManager = appUserManager;
      _mapper = mapper
      ;
    }

    #endregion Constructor

    [HttpPut("[namespace]")]
    [SwaggerOperation(
        Summary = "Update employee.",
        Description = "Update employee.",
        OperationId = "Employee.Update",
        Tags = new[] { "EmployeeEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(EmployeeDto request, CancellationToken cancellationToken = default)
    {
      var item = await this._appUserManager.FindByIdAsync(request.Id.ToString());

      if (item != null)
      {
        var resultMapping = _mapper.Map(request, item);
        var updateResult = await this._appUserManager.UpdateAsync(resultMapping);
        if (updateResult.Succeeded)
        {
          return Ok();
        }
        return BadRequest();
      }

      return BadRequest();
    }

  }
}