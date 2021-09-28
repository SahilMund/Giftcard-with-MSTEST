using AutoMapper;
using GiftCardApi.Controllers;
using GiftCardApi.CustomExceptions;
using GiftCardApi.Models;
using GiftCardApi.Models.Dtos;
using GiftCardApi.Models.Profiles;
using GiftCardApi.Repository.Interfaces;
using GiftCardApi.Services;
using GiftCardApi.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCardApiTest
{
    [TestClass]
    public class GiftCardServicesTest
    {
        [TestMethod]
        public async Task CreateTest()
        {
            Mock<IGiftCardRepo> mockRepo = new Mock<IGiftCardRepo>();

            GiftCardProfile myProfile = new GiftCardProfile();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            GiftCardModel giftCard = new GiftCardModel()
            {
                GiftCardId = 0,
                BuyerName = "PQR",
                RecipientName = "Test User",
                ShippingAddress = "XYZ Street, PQR City, State, Country, PIN CODE: 789654",
                StreetAddress = "XYZ Street",
                City = "PQR City",
                State = "State",
                Country = "___Country",
                PinCode = "789654",
                Email = "user@example.com",
                Gender = "Male",
                Occassion = "Birthday",
                Amount = 20000,
                Phone = "9876543211"
            };

            GiftCardCreateDto giftCardCreateDto = new GiftCardCreateDto()
            {
                BuyerName = "PQR",
                RecipientName = "Test User",
                StreetAddress = "XYZ Street",
                City = "PQR City",
                State = "State",
                Country = "Country",
                PinCode = "789654",
                Email = "user@example.com",
                Gender = "Male",
                Occassion = "Birthday",
                Amount = 20000,
                Phone = "9876543211"
            };

            GiftCardReadDto giftCardReadDto = new GiftCardReadDto()
            {
                GiftCardId = 0,
                BuyerName = "PQR",
                ShippingAddress = "XYZ Street, PQR City, State, Country, PIN CODE: 789654",
                City = "PQR City",
                Amount = 20000,
                Phone = "9876543211"
            };

            mockRepo.Setup(p => p.Create(giftCard));
            mockRepo.Setup(p => p.SaveChanges()).ReturnsAsync(true);

            IGiftCardServices services = new GiftCardService(mockRepo.Object, mapper);

            GiftCardReadDto output = await services.Create(giftCardCreateDto);

            Assert.IsTrue(Helper.CheckObject(output, giftCardReadDto));
        }

        [TestMethod]
        public async Task GetAllPassTest()
        {
            Mock<IGiftCardRepo> mockRepo = new Mock<IGiftCardRepo>();

            GiftCardProfile myProfile = new GiftCardProfile();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            List<GiftCardReadDto> giftCardReadDtoList = new List<GiftCardReadDto>();

            GiftCardReadDto giftCardReadDto = new GiftCardReadDto()
            {
                GiftCardId = 0,
                BuyerName = "PQR",
                ShippingAddress = "XYZ Street, PQR City, State, Country, PIN CODE: 789654",
                City = "PQR City",
                Amount = 20000,
                Phone = "9876543211"
            };

            GiftCardModel giftCard = new GiftCardModel()
            {
                GiftCardId = 0,
                BuyerName = "PQR",
                RecipientName = "Test User",
                ShippingAddress = "XYZ Street, PQR City, State, Country, PIN CODE: 789654",
                StreetAddress = "XYZ Street",
                City = "PQR City",
                State = "State",
                Country = "___Country",
                PinCode = "789654",
                Email = "user@example.com",
                Gender = "Male",
                Occassion = "Birthday",
                Amount = 20000,
                Phone = "9876543211"
            };
            
            List<GiftCardModel> giftCardList = new List<GiftCardModel>();

            giftCardReadDtoList.Add(giftCardReadDto);
            giftCardList.Add(giftCard);

            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(giftCardList);

            IGiftCardServices services = new GiftCardService(mockRepo.Object, mapper);

            List<GiftCardReadDto> output = (await services.GetAll()).ToList();

            Assert.IsTrue(Helper.CheckList(output, giftCardReadDtoList));
        }

        [TestMethod]
        public async Task GetAllFailTest()
        {
            Mock<IGiftCardRepo> mockRepo = new Mock<IGiftCardRepo>();

            GiftCardProfile myProfile = new GiftCardProfile();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            List<GiftCardModel> giftCardList = new List<GiftCardModel>();

            //mockRepo.Setup(p => p.GetAll()).ThrowsAsync(new NoDataAvailableException("No Data in the Database"));
            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(giftCardList);

            IGiftCardServices services = new GiftCardService(mockRepo.Object, mapper);

            await Assert.ThrowsExceptionAsync<NoDataAvailableException>(() => services.GetAll());
        }
    }
}
