using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Phonebook.DTO;
using Phonebook.Microservice.Entities;


namespace Phonebook.Tests.Services
{
    [TestClass]
    public class FindAddressPointTests : AddressPointServiceTestsBase
    {
        [TestMethod]
        public async Task FindAddressPoint_ShouldReturnAddressPoint()
        {
            var request = new PhonebookRequest
            {
                City = "Warszawa",
                Street = "Achera",
                Nr = "11",
                Code = "02-495"
            };

            var ap = new AddressPoint
            {
                Province = "14",
                District = "1465",
                Commune = "1465128",
                CitySub = "Ursus",
                X = 20.8900666174465,
                Y = 52.19725528006866,
                City = "Warszawa",
                Street = "Franciszka Adolfa Achera",
                Nr = "11",
                Code = "02-495"
            };

            // Arrange
            repository.Setup(r => r.FindAddressPointAsync(request)).ReturnsAsync(ap);

            // Act
            var result = await addressPointService.FindAddressPointAsync(request);

            // Assert
            Assert.AreEqual(result.City, ap.City);
            Assert.IsTrue(ap.Street.Contains(request.Street));
        }

        [TestMethod]
        public async Task FindAddressPoint_ShouldFail()
        {
            AddressPoint ap = null;

            // Arrange
            repository.Setup(r => r.FindAddressPointAsync(It.IsAny<PhonebookRequest>())).ReturnsAsync(ap);

            // Act
            var result = await addressPointService.FindAddressPointAsync(It.IsAny<PhonebookRequest>());

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task FindAddressPoint_ThrowsException()
        {
            AddressPoint? ap = null;

            // Arrange
            repository.Setup(r => r.FindAddressPointAsync(It.IsAny<PhonebookRequest>())).ReturnsAsync(ap);

            // Act
            var result = await addressPointService.FindAddressPointAsync(It.IsAny<PhonebookRequest>());

            Func<Task> actual = () => addressPointService.FindAddressPointAsync((PhonebookRequest)null); 

            // Assert
            Assert.ThrowsExceptionAsync<OverflowException>(actual);
        }
    }
}
