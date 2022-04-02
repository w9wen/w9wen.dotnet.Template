using w9wen.dotnet.Template.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace w9wen.dotnet.Template.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlite(connectionString)); // will be created in web project root
}
