using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PremiumCalculatorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace PremiumCalculatorApp.Controllers
{
    [Route("api/[controller]")]
    public class RefDataController : Controller
    {
        private IRefDataRepository _refDataRepository;

        public RefDataController(IRefDataRepository refDataRepository)
        {
            _refDataRepository = refDataRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetReferenceData()
        {
            try
            {
                var result = _refDataRepository.GetReferenceData();

                if (result != null && result.Data != null)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError.ToString(), string.Empty);
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError.ToString(), string.Empty);
            }
        }

    }
}
