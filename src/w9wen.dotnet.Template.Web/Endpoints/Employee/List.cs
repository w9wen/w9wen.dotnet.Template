using Ardalis.ApiEndpoints;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public List(AppUserManager appUserManager, IMapper mapper)
    {
      _appUserManager = appUserManager;
      _mapper = mapper;
    }
    [HttpGet(EmployeeListRequest.Route)]
    [SwaggerOperation(
        Summary = "Gets a list of all employees",
        Description = "Gets a list of all employees",
        OperationId = "Employee.List",
        Tags = new[] { "EmployeeEndpoints" })
    ]
    public override async Task<ActionResult<IEnumerable<EmployeeDto>>> HandleAsync([FromQuery] EmployeeListRequest request, CancellationToken cancellationToken = default)
    {
      var query = _appUserManager.Users;

      if (string.IsNullOrEmpty(request.Gender)) query = query.Where(x => x.Gender == request.Gender);
      if (string.IsNullOrEmpty(request.City)) query = query.Where(x => x.City == request.City);
      if (string.IsNullOrEmpty(request.Country)) query = query.Where(x => x.Country == request.Country);

      query = request.OrderBy switch
      {
        "createdDateTime"
          => query.OrderByDescending(x => x.CreatedDateTime),
        _ => query.OrderByDescending(x => x.UserName)

      };
      return _mapper.Map<List<EmployeeDto>>(query.ToList());
    }
  }
}