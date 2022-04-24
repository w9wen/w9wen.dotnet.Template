using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.w9wen.dotnet.Template.Web.Endpoints.Employee;
using w9wen.dotnet.Template.Core.Entities;

namespace w9wen.dotnet.Template.Web.Configurations
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<AppUserEntity, EmployeeDto>();
    }
  }
}
