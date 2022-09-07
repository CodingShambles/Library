using Contracts;
using Entities;

namespace Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repositoryContext;
    private IAddressRepository _address;
    private IBookRepository _book;
    private IBorrowmentRepository _borrowment;
    private IPersonRepository _person;

    public IAddressRepository Address
    {
        get {
            if(_address is null)
            {
                _address = new AddressRepository(_repositoryContext);
            }

            return _address;
        }
    }

    public IBookRepository Book
    {
        get
        {
            if(_book is null)
            {
                _book = new BookRepository(_repositoryContext);
            }

            return _book;
        }
    }

    public IBorrowmentRepository Borrowment
    {
        get
        {
            if(_borrowment is null)
            {
                _borrowment = new BorrowmentRepository(_repositoryContext);
            }

            return _borrowment;
        }
    }

    public IPersonRepository Person
    {
        get
        {
            if(_person is null)
            {
                _person = new PersonRepository(_repositoryContext);
            }

            return _person;
        }
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}