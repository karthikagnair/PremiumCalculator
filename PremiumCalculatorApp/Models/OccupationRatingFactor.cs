using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculatorApp.Models
{
    public class OccupationRatingFactorDto
    {
        public int RatingId { get; set; }
        public string Rating { get; set; }
        public decimal Factor { get; set; }
    }
}