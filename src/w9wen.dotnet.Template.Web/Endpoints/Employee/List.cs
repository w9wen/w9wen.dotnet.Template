using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using src.w9wen.dotnet.Template.Web.Endpoints.Employee;
using Swashbuckle.AspNetCore.Annotations;
using w9wen.dotnet.Template.Infrastructure.Data;

namespace w9wen.dotnet.Template.Web.Endpoints.Employee
{
  public class List : EndpointBaseAsync
    .WithRequest<EmployeeListRequest>
    .WithActionResult<IEnumerable<EmployeeDto>>
  {
    private readonly AppUserManager _appUserManager;

    public List(AppUserManager appUserManager)
    {
      _appUserManager = appUserManager;
    }
    [HttpGet(EmployeeListRequest.Route)]
    [SwaggerOperation(
        Summary = "Gets a list of all employees",
        Description = "Gets a list of all employees",
        OperationId = "Employee.List",
        Tags = new[] { "EmployeeEndpoints" })
    ]
    public override Task<ActionResult<IEnumerable<EmployeeDto>>> HandleAsync([FromQuery] EmployeeListRequest request, CancellationToken cancellationToken = default)
    {
      var query = _appUserManager.Users;
      query = query.Where(x => x.Gender == request.Gender);
      query = query.Where(x => x.City == request.City);
      query = query.Where(x => x.Country == request.Country);

      query = request.OrderBy switch
      {
        "createdDateTime" 
              => query.OrderByDescending(x => x.CreatedDateTime),
            _ => query.OrderByDescending(x => x.UserName)

      };

      throw new NotImplementedException();
    }
  }
}