using Entities.Models;

namespace Contracts;

public interface IAddressRepository : IRepositoryBase<Address>
{
    IEnumerable<Address> GetAllAddresses();
    Address GetAddressById(Guid addressId);
    Address GetAddressWithDetails(Guid personId);
    void CreateAddress(Address address);
}