using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using VivaWallet.Models;

namespace VivaWallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetInteger : ControllerBase
    {
        [HttpPost]
        public IActionResult GetSecondLargestInteger(RequestObj request)
        {
            try
            {
                if (request == null || request.RequestArrayObj == null)
                {
                    return BadRequest("The array must contain at least two integers.");
                }

                if(request.RequestArrayObj.Any(x => x < 1) || request.RequestArrayObj.Any(x => x > 255))
                {
                    return BadRequest("The array should contain integers with range 1 to 255.");
                }
                else if (request.RequestArrayObj.Count < 2)
                {
                    return BadRequest("The array must contain at least two integers");
                }

                int secondLargest = request.RequestArrayObj.Distinct().OrderByDescending(x => x).Skip(1).FirstOrDefault();

                if(secondLargest == 0)
                {
                    return BadRequest("The array must contain at least two integers");
                }

                return Ok(secondLargest);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
