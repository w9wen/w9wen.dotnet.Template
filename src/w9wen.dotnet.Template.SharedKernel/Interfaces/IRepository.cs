using Ardalis.Specification;

namespace w9wen.dotnet.Template.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
