using w9wen.dotnet.Template.Core.ProjectAggregate;
using w9wen.dotnet.Template.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace w9wen.dotnet.Template.Web;

public static class SeedData
{
  public static readonly Project TestProject1 = new Project("Test Project", PriorityStatus.Backlog);

  private static DateTime now = DateTime.Now;

  private static string systemUser = "System";

  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Title = "Get Sample Working",
    Description = "Try to get the sample to build.",
    CreatedUser = systemUser,
    CreatedDateTime = now,
    UpdatedUser = systemUser,
    UpdatedDateTime = now,
    ValidFlag = true,
  };
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another.",
    CreatedUser = systemUser,
    CreatedDateTime = now,
    UpdatedUser = systemUser,
    UpdatedDateTime = now,
    ValidFlag = true,
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing.",
    CreatedUser = systemUser,
    CreatedDateTime = now,
    UpdatedUser = systemUser,
    UpdatedDateTime = now,
    ValidFlag = true,
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {

      dbContext.Database.MigrateAsync().GetAwaiter().GetResult();

      // Look for any TODO items.
      if (dbContext.ToDoItems.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);

    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Projects)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestProject1.CreatedUser = systemUser;
    TestProject1.CreatedDateTime = now;
    TestProject1.UpdatedUser = systemUser;
    TestProject1.UpdatedDateTime = now;
    TestProject1.ValidFlag = true;

    TestProject1.AddItem(ToDoItem1);
    TestProject1.AddItem(ToDoItem2);
    TestProject1.AddItem(ToDoItem3);
    dbContext.Projects.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
