using System;
using System.Collections.Generic;
using PremiumCalculatorApp.Models;
using dl= DataLibrary;

namespace PremiumCalculatorApp.Services
{
    public interface IRefDataRepository
    {
        Result<ReferenceData> GetReferenceData();
    }
    public class RefDataRepository : IRefDataRepository
    {
        IRefDataService _refDataService;
        public RefDataRepository(IRefDataService refDataService)
        {
            _refDataService = refDataService;
        }
        public Result<ReferenceData> GetReferenceData()
        {
            try
            {
                var occupationRatingData = _refDataService.InvokeOccupationRating();
                List<OccupationRatingDto> occupationRatings = new List<OccupationRatingDto>();
                foreach(dl.OccupationRating or in occupationRatingData.Data)
                {
                    OccupationRatingDto rating = new OccupationRatingDto()
                    {
                        Occupation = or.Occupation,
                        RatingId = or.RatingId,
                        OccupationId=or.OccupationId
                    };
                    occupationRatings.Add(rating);
                }

                var ratingFactorData = _refDataService.InvokeOccupationRatingFactor();
                List<OccupationRatingFactorDto> occupationRatingFactors = new List<OccupationRatingFactorDto>();
                foreach (dl.OccupationRatingFactor orf in ratingFactorData.Data)
                {
                    OccupationRatingFactorDto ratingFactor = new OccupationRatingFactorDto()
                    {
                        Factor = orf.Factor,
                        Rating = orf.Rating,
                        RatingId=orf.RatingId
                    };
                    occupationRatingFactors.Add(ratingFactor);
                }
                List<ReferenceData> referenceData = new List<ReferenceData>();
                ReferenceData rd = new ReferenceData()
                {
                    OccupationRating = occupationRatings,
                    RatingFactor = occupationRatingFactors
                };
                referenceData.Add(rd);

                return new Result<ReferenceData>
                {
                    Data = referenceData,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch(Exception)
            {
                return new Result<ReferenceData>
                {
                    Data = null,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}