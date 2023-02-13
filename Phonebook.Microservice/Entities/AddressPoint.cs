namespace Phonebook.Microservice.Entities
{
    public class AddressPoint : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Nr { get; set; }
        public string Code { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }
        public string CitySub { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
