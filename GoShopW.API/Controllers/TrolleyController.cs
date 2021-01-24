using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoShopW.Contracts;
using GoShopW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoShopW.Controllers
{
    [ApiController]
    [Route("api/trolleyTotal")]
    public class TrolleyController : ControllerBase
    {
        private readonly ILogger<TrolleyController> _logger;
        private readonly ITrolleyService _trolleyService;

        public TrolleyController(
            ITrolleyService trolleyService,
            ILogger<TrolleyController> logger)
        {
            _trolleyService = trolleyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetTrolleyTotal([FromBody] Trolley trolley)
        {
            // return new JsonResult(await this._trolleyService.GetTrolleyTotal(trolley));
            return new JsonResult(await this._trolleyService.GetTrolleyTotalWithCalculatorService(trolley));
        }
    }
}
