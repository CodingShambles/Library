namespace Contracts;

public interface IRepositoryWrapper
{
    IAddressRepository Address { get; }
    IBookRepository Book { get; }
    IBorrowmentRepository Borrowment { get; }
    IPersonRepository Person { get; }
    void Save();
}
