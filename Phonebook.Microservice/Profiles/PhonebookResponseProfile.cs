using AutoMapper;
using Phonebook.DTO;
using Phonebook.Microservice.Entities;

namespace Phonebook.Microservice.Profiles
{
    public class PhonebookResponseProfile : Profile
    {
        public PhonebookResponseProfile()
        {
            CreateMap<AddressPoint, PhonebookResponse>().ReverseMap();
        }
    }
}
