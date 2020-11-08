using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using System.Text.Json;
using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.Services;
using PremiumCalculatorApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using dl=DataLibrary;

namespace PremiumCalculatorApp.UnitTests
{

    [TestFixture]
    class RefDataServiceTest
    {
        private string _orJsonResult, _orfJsonResult;

        [SetUp]
        public void SetUp()
        {

            List<dl.OccupationRating> _occupationRating = new List<dl.OccupationRating>
            {
                   new dl.OccupationRating(){Occupation = "Doctor", RatingId =1}
            };

            _orJsonResult = JsonSerializer.Serialize(_occupationRating);

           List<dl.OccupationRatingFactor> _occupationRatingFactor = new List<dl.OccupationRatingFactor>
            {                
                    new dl.OccupationRatingFactor(){Factor = 1.5M, Rating="Professional", RatingId=1}               
            };

            _orfJsonResult = JsonSerializer.Serialize(_occupationRatingFactor);
        }
        [Test]
        public void InvokeOccupationRating()
        {
            // Arrange
            var refDataService = new RefDataService();         

            // Act
            var result = refDataService.InvokeOccupationRating();

            var refData = result.Data as List<dl.OccupationRating>;

            // Assert
            Assert.IsNotNull(refData);
            Assert.IsNotNull(refData[0]);
            Assert.AreEqual("Cleaner", refData[0].Occupation);
            Assert.AreEqual(6, refData.Count);
        }

        [Test]
        public void InvokeOccupationRatingFactor()
        {
            //Arrange
            var refDataService = new RefDataService();

            // Act
            var result = refDataService.InvokeOccupationRatingFactor();

            var refData = result.Data as List<dl.OccupationRatingFactor>;

            // Assert
            Assert.IsNotNull(refData);
            Assert.IsNotNull(refData[0]);
            Assert.AreEqual(1.0M, refData[0].Factor);
            Assert.AreEqual(4, refData.Count);
        }
    }
}
