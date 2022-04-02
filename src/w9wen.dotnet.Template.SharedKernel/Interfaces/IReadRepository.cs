using Ardalis.Specification;

namespace w9wen.dotnet.Template.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
