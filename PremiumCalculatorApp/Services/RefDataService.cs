using System;
using System.Collections.Generic;
using dl = DataLibrary;
using System.Text.Json;
using PremiumCalculatorApp.Models;

namespace PremiumCalculatorApp.Services
{
    public interface IRefDataService
    {
        Result<dl.OccupationRating> InvokeOccupationRating();
        Result<dl.OccupationRatingFactor> InvokeOccupationRatingFactor();
    }
    public class RefDataService : IRefDataService
    {
        public RefDataService()
        {

        }
        public Result<dl.OccupationRating> InvokeOccupationRating()
        {
            try
            {
                List<dl.OccupationRating> occupationRating =
                      JsonSerializer.Deserialize<List<dl.OccupationRating>>(dl.OccupationRatingDetails.GetOccupationRatingDetails());

                return new Result<dl.OccupationRating>
                {
                    Data = occupationRating,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch(Exception)
            {
                return new Result<dl.OccupationRating>
                {
                    Data = null,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Result<dl.OccupationRatingFactor> InvokeOccupationRatingFactor()
        {
            try
            {
                List<dl.OccupationRatingFactor> occupationRatingFactor =
                    JsonSerializer.Deserialize<List<dl.OccupationRatingFactor>>(dl.OccupationRatingFactorDetails.GetRatingFactor());

                return new Result<dl.OccupationRatingFactor>
                {
                    Data = occupationRatingFactor,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                return new Result<dl.OccupationRatingFactor>
                {
                    Data = null,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}