using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoShopW.Contracts;
using GoShopW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoShopW.Controllers
{
    /// <summary>
    /// Endpoint which facilitate trolley total calculations via <see cref="ITrolleyService"/>.
    /// </summary>
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTrolleyTotal([FromBody] Trolley trolley)
        {
            // TODO - below commented code is kept to check trolley count from external endpoint.
            // return new JsonResult(await this._trolleyService.GetTrolleyTotal(trolley));

            return new JsonResult(await this._trolleyService.GetTrolleyTotalWithCalculatorService(trolley));
        }
    }
}
