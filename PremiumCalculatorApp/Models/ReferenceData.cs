using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculatorApp.Models
{
    public class ReferenceData
    {
        public List<OccupationRatingDto> OccupationRating{get; set; }
        public List<OccupationRatingFactorDto> RatingFactor { get; set; }
    }
}