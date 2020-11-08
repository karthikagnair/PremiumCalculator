using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.Services;
using PremiumCalculatorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using DataLibrary;

namespace PremiumCalculatorApp.UnitTests
{
    [TestFixture]
    class RefDataRepositoryTest
    {
        Result<OccupationRating> _occupationRating;
        Result<OccupationRatingFactor> _occupationRatingFactor;
        [SetUp]
        public void SetUp()
        {

            _occupationRating = new Result<OccupationRating>
            {
                Data = new System.Collections.Generic.List<OccupationRating>()
                {
                    new OccupationRating(){Occupation = "Doctor", RatingId =1}
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };

            _occupationRatingFactor = new Result<OccupationRatingFactor>
            {
                Data = new System.Collections.Generic.List<OccupationRatingFactor>()
                {
                    new OccupationRatingFactor(){Factor = 1.5M, Rating="Professional", RatingId=1}
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        [Test]
        public void GetReferenceData()
        {
            // Arrange
            var refDataService = Substitute.For<IRefDataService>();
            var refDataRepository = new RefDataRepository(refDataService);

            refDataService.InvokeOccupationRating().Returns<Result<OccupationRating>>(_occupationRating);
            refDataService.InvokeOccupationRatingFactor().Returns<Result<OccupationRatingFactor>>(_occupationRatingFactor);

            // Act
            var result = refDataRepository.GetReferenceData();

            var refData = result.Data as List<ReferenceData>;

            // Assert
            Assert.IsNotNull(refData);
            Assert.IsNotNull(refData[0].OccupationRating);
            Assert.AreEqual("Doctor", refData[0].OccupationRating[0].Occupation);
            Assert.IsNotNull(refData[0].RatingFactor);
            Assert.AreEqual(1.5M, refData[0].RatingFactor[0].Factor);
            Assert.AreEqual(1, refData.Count);
        }
    }

}
