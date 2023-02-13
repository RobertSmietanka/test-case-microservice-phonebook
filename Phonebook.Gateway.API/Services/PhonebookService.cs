using Phonebook.DTO;
using Phonebook.Gateway.WebAPI.Url;

namespace Phonebook.Gateway.WebAPI.Services
{
    public class PhonebookService : IPhonebookService
    {
        private readonly HttpClient client;

        public PhonebookService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<PhonebookResponse> FindAddressPointAsync(PhonebookRequest requestData)
        {
            var response = await client.PostAsJsonAsync<PhonebookRequest>(PhonebookOperations.FindAddressPoint(), requestData);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PhonebookResponse>();
        }
    }
}
