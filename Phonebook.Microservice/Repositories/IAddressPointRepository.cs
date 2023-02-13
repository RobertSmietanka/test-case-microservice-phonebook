using Phonebook.DTO;
using Phonebook.Microservice.Entities;

namespace Phonebook.Microservice.Repositories
{
    public interface IAddressPointRepository
    {
        Task<AddressPoint> FindAddressPointAsync(PhonebookRequest filterData);
    }
}
