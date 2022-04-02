using Autofac;
using w9wen.dotnet.Template.Core.Interfaces;
using w9wen.dotnet.Template.Core.Services;

namespace w9wen.dotnet.Template.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
