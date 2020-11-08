using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.Services;
using PremiumCalculatorApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PremiumCalculator.Tests.Api
{
    [TestFixture]
    public class RefDataControllerTest
    {
        Result<ReferenceData> _result;

        [SetUp]
        public void SetUp()
        {
            List<ReferenceData> rdList = new List<ReferenceData>();
            ReferenceData rd = new ReferenceData()
            {
                OccupationRating = new System.Collections.Generic.List<OccupationRatingDto>()
                {
                    new OccupationRatingDto(){Occupation = "Doctor", RatingId =1}
                },
                RatingFactor = new System.Collections.Generic.List<OccupationRatingFactorDto>()
                {
                    new OccupationRatingFactorDto()
                    {
                        RatingId=1, Factor = 1.5M
                    }
                }
            };
            rdList.Add(rd);
            _result = new Result<ReferenceData>()
            {
                Data = rdList,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        [Test]
        public void GetReferenceData()
        {
            // Arrange
            var refDataService = Substitute.For<IRefDataService>();
            var refDataRepository = Substitute.For<IRefDataRepository>();
            var controller = new RefDataController(refDataRepository);
            refDataRepository.GetReferenceData().Returns<Result<ReferenceData>>(_result);

            // Act
            IActionResult actionResult = controller.GetReferenceData();

            var contentResult = actionResult as OkObjectResult;
            var refData = contentResult.Value as List<ReferenceData>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            Assert.IsNotNull(refData);
            Assert.AreEqual(1, refData.Count);
        }
    }
}
