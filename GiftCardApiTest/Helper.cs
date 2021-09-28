using GiftCardApi.Models.Dtos;
using System;
using System.Collections.Generic;

namespace GiftCardApiTest
{
    public class Helper
    {
        public static bool CheckList(List<GiftCardReadDto> list1, List<GiftCardReadDto> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].GiftCardId == list2[i].GiftCardId && list1[i].BuyerName == list2[i].BuyerName && list1[i].ShippingAddress == list2[i].ShippingAddress &&
                    list1[i].City == list2[i].City && list1[i].Amount == list2[i].Amount && list1[i].Phone == list2[i].Phone)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckObject(GiftCardReadDto giftCard1, GiftCardReadDto giftCard2)
        {
            Console.WriteLine(giftCard1.GiftCardId + " | " + giftCard2.GiftCardId);
            Console.WriteLine(giftCard1.BuyerName + " | " + giftCard2.BuyerName);
            Console.WriteLine(giftCard1.ShippingAddress + " | " + giftCard2.ShippingAddress);
            Console.WriteLine(giftCard1.City + " | " + giftCard2.City);
            Console.WriteLine(giftCard1.Amount + " | " + giftCard2.Amount);
            Console.WriteLine(giftCard1.Phone + " | " + giftCard2.Phone);

            if (giftCard1.GiftCardId == giftCard2.GiftCardId && giftCard1.BuyerName == giftCard2.BuyerName && giftCard1.ShippingAddress == giftCard2.ShippingAddress &&
                giftCard1.City == giftCard2.City && giftCard1.Amount == giftCard2.Amount && giftCard1.Phone == giftCard2.Phone)
            {
                Console.WriteLine("True");
                return true;
            }
            Console.WriteLine("False");
            return false;
        }
    }
}