using Hangfire;
using Hangfire.PostgreSql;

namespace w9wen.dotnet.Template.Web.Configurations
{
  public static class CoreServicesConfiguration
  {
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddAutoMapper(typeof(MappingProfile).Assembly);
      services.AddHangfire(config =>
            config.UsePostgreSqlStorage(configuration.GetConnectionString("DefaultConnection")));

      services.AddHangfireServer();

    }
  }
}
