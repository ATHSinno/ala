using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOffersBL.Entities
{
    public class HotelOffer
    {
        public string HotelName { get; set; }
        public string HotelUrl { get; set; }
        public string HotelImageUrl { get; set; }
        public double StarRating { get; set; }
        public double GuestReviewRating { get; set; }
        public int TotalReview { get; set; }
        public double Price { get; set; }


    }
}
