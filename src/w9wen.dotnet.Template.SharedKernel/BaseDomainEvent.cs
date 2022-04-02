using MediatR;

namespace w9wen.dotnet.Template.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
