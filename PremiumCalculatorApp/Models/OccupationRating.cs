using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculatorApp.Models
{
    public class OccupationRatingDto
    {
        public int OccupationId { get; set; }
        public int RatingId { get; set; }
        public string Occupation { get; set; }
    }
}