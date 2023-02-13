using Phonebook.DTO;
using Phonebook.Microservice.Entities;

namespace Phonebook.Microservice.Services
{
    public interface IAddressPointService
    {
        Task<AddressPoint> FindAddressPointAsync(PhonebookRequest requestData);
    }
}
