using GiftCardApi.Controllers;
using GiftCardApi.Models.Dtos;
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
    public class GiftCardsControllerTest
    {
        [TestMethod]
        public async Task HttpGetTest()
        {
            Mock<IGiftCardServices> mockGet = new Mock<IGiftCardServices>();

            List<GiftCardReadDto> giftCardList = new List<GiftCardReadDto>();

            GiftCardReadDto giftCard = new GiftCardReadDto()
            {
                GiftCardId = 2,
                BuyerName = "Test Person",
                ShippingAddress = "XYZ Street, PQR City, __Country",
                City = "PQR City",
                Amount = 4000,
                Phone = "9876543211"
            };

            giftCardList.Add(giftCard);

            mockGet.Setup(p => p.GetAll()).ReturnsAsync(giftCardList);

            GiftCardsController controller = new GiftCardsController(mockGet.Object);

            List<GiftCardReadDto> output = (await controller.GetAll()).ToList();

            Console.WriteLine(output[0].BuyerName);
            Console.WriteLine(giftCardList[0].BuyerName);

            Assert.IsTrue(Helper.CheckList(output, giftCardList));
        }

        [TestMethod]
        public async Task HttpPassPostTest()
        {
            Mock<IGiftCardServices> mockPost = new Mock<IGiftCardServices>();

            GiftCardCreateDto giftCard = new GiftCardCreateDto()
            {
                BuyerName = "PQR",
                RecipientName = "Test User",
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

            GiftCardReadDto giftCardReadDto = new GiftCardReadDto()
            {
                GiftCardId = 2,
                BuyerName = "PQR",
                ShippingAddress = "XYZ Street, PQR City, __Country",
                City = "PQR City",
                Amount = 20000,
                Phone = "9876543211"
            };

            string passOutput = "Gift card added successfully";

            mockPost.Setup(p => p.Create(giftCard)).ReturnsAsync(giftCardReadDto);

            GiftCardsController controller = new GiftCardsController(mockPost.Object);

            string output = (await controller.Create(giftCard)).ToString();

            Assert.AreEqual(passOutput, output);
        }

        [TestMethod]
        public async Task HttpFailPostTest()
        {
            Mock<IGiftCardServices> mockPost = new Mock<IGiftCardServices>();

            GiftCardCreateDto giftCard = new GiftCardCreateDto();
            GiftCardReadDto failGiftRead = null;

            mockPost.Setup(p => p.Create(giftCard)).ReturnsAsync(failGiftRead);

            GiftCardsController controller = new GiftCardsController(mockPost.Object);

            string output = (await controller.Create(giftCard)).ToString();
            string failOutput = "Gift card addition unsuccessfull";

            Assert.AreEqual(failOutput, output);
        }
    }
}
