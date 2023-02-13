using AutoMapper;
using Phonebook.DTO;
using Phonebook.Microservice.Entities;
using Phonebook.Microservice.Repositories;

namespace Phonebook.Microservice.Services
{
    public class AddressPointService : IAddressPointService
    {
        private readonly IAddressPointRepository _addressPointRepository;

        public AddressPointService(IAddressPointRepository addressPointRepository)
        {
            _addressPointRepository = addressPointRepository;
        }

        public async Task<AddressPoint> FindAddressPointAsync(PhonebookRequest requestData)
        {
            return await _addressPointRepository.FindAddressPointAsync(requestData);
        }
    }
}
