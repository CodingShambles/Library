using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Address> GetAllAddresses()
    {
        return FindAll()
            .OrderBy(add => add.City)
            .ToList();
    }

    public Address GetAddressById(Guid addressId)
    {

#pragma warning disable CS8603 // Possible null reference return.
        return FindByCondition(add => add.Id.Equals(addressId))
            .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public Address GetAddressWithDetails(Guid personId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return FindByCondition(add => add.Resident.Id.Equals(personId))
            .Include(person => personId)
            .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void CreateAddress(Address address)
    {
        Create(address);
    }
}