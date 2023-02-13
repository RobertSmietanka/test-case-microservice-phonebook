using AutoFixture;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Phonebook.Microservice.Repositories;
using Phonebook.Microservice.Services;


namespace Phonebook.Tests.Services
{
    public class AddressPointServiceTestsBase
    {
        protected Mock<IAddressPointRepository> repository;
        protected AddressPointService addressPointService;
        protected Fixture fixture;


        [TestInitialize]
        public void Setup()
        {
            fixture = new Fixture();

            repository = new Mock<IAddressPointRepository>();

            addressPointService = new AddressPointService(repository.Object);
        }
    }
}
