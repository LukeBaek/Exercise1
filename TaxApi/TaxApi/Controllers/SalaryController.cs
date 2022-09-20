#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tax.Services;
using Tax.Services.DTOs;
using TaxApi.Models;

namespace TaxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        public SalaryController()
        {
            _taxService = new TaxServices();
        }

        [HttpGet()]
        public ActionResult<string[]> Get()
        {
            return _taxService.GetBandInfo()
                .Select(x =>
                    new BandInfoModel
                    {
                        bandNumber = x.BandNumber,
                        maxAmount = x.MaxAmount,
                        percentage = x.Percentage,
                        startAmount = x.StartAmount
                    }.ToString()
                ).ToArray();
        }

        [HttpPost()]
        public ActionResult<string> Get(TaxBandModel band)
        {
            return "salary";
        }

        [HttpGet("calculate/{salary}")]
        public ActionResult<String> Get(decimal salary)
        {
            return _taxService.GetMyTotalTax(salary).ToString();
        }

        [HttpPut("{id}")]
        public void Post([FromBody] string value)
        {
        }

        private readonly TaxServices _taxService;
    }
}
