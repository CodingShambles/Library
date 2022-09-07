using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class BorrowmentRepository : RepositoryBase<Borrowment>, IBorrowmentRepository
{
    public BorrowmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}