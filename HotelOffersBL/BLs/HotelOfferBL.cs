using HotelOffersBL.Entities;
using HotelOffersSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HotelOffersBL.BLs
{
    public class HotelOfferBL
    { 
        public List<HotelOffer> GetOfferJson(string Url)
        {
            HotelOffers hotelOffersObj = new HotelOffers();
            List<HotelOffer> lstOffers = new List<HotelOffer>();
            string json = hotelOffersObj.GetOffersJson(Url);
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic jsonObject = js.Deserialize<dynamic>(json);
            if (jsonObject["offers"] != null)
                if (jsonObject["offers"]["Hotel"] != null)
                {

                    foreach (var item in jsonObject["offers"]["Hotel"])
                    {
                        HotelOffer hotelOffer = new HotelOffer
                        {
                            HotelName = Convert.ToString(item["hotelInfo"]["hotelName"]),
                            HotelUrl = Convert.ToString(item["hotelUrls"]["hotelInfositeUrl"]),
                            HotelImageUrl = Convert.ToString(item["hotelInfo"]["hotelImageUrl"]),
                            GuestReviewRating = Convert.ToDouble(item["hotelInfo"]["hotelGuestReviewRating"]),
                            StarRating = Convert.ToDouble(item["hotelInfo"]["hotelStarRating"]),
                            TotalReview = Convert.ToInt32(item["hotelInfo"]["hotelReviewTotal"]),
                            Price = Convert.ToDouble(item["hotelPricingInfo"]["originalPricePerNight"])
                        };
                        lstOffers.Add(hotelOffer);
                    }

                }
            return lstOffers;
        }
    }
}
