using Microsoft.EntityFrameworkCore;

using Phonebook.DTO;
using Phonebook.Microservice.DbContexts;
using Phonebook.Microservice.Entities;

namespace Phonebook.Microservice.Repositories
{
    public class AddressPointRepository : IAddressPointRepository
    {
        private readonly PhonebookContext _phonebookContext;

        public AddressPointRepository(PhonebookContext phonebookContext)
        {
            _phonebookContext = phonebookContext;
        }

        public async Task<AddressPoint> FindAddressPointAsync(PhonebookRequest filterData)
        {
            if (filterData == null) throw new ArgumentNullException(nameof(filterData));

            return await _phonebookContext.AddressPoints.Where(ap => ap.City == filterData.City &&
                                                                     ap.Street.Contains(filterData.Street) &&
                                                                     ap.Nr == filterData.Nr &&
                                                                     ap.Code == filterData.Code).FirstOrDefaultAsync();
        }
    }
}
