using Ardalis.Specification.EntityFrameworkCore;
using w9wen.SharedKernel.Interfaces;

namespace w9wen.dotnet.Template.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
