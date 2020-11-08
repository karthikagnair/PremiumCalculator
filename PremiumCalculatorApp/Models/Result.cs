using System.Collections.Generic;
using System.Net;

namespace PremiumCalculatorApp.Models
{
    public class Result<T>
    {
        public List<T> Data { get; set; }
        public HttpStatusCode StatusCode { get; set; } 
    }
}