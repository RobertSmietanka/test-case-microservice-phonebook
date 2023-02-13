using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Microservice.Entities.Mappings
{
    public class AddressPointMap 
    {
        public AddressPointMap(EntityTypeBuilder<AddressPoint> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.City).IsRequired();
            entityBuilder.Property(t => t.Street).IsRequired();
            entityBuilder.Property(t => t.Nr).IsRequired();
            entityBuilder.Property(t => t.Code).IsRequired();
            entityBuilder.Property(t => t.Province).IsRequired();
            entityBuilder.Property(t => t.District).IsRequired();
            entityBuilder.Property(t => t.Commune).IsRequired();
            entityBuilder.Property(t => t.CitySub).IsRequired();
            entityBuilder.Property(t => t.X).IsRequired();
            entityBuilder.Property(t => t.Y).IsRequired();
        }
    }
}
