using Phonebook.DTO;

namespace Phonebook.Gateway.WebAPI.Services
{
    public interface IPhonebookService
    {
        Task<PhonebookResponse> FindAddressPointAsync(PhonebookRequest requestData);
    }
}
