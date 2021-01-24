using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoShopW.Contracts;
using GoShopW.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoShopW.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class ProductSortController : ControllerBase
    {
        private readonly ISortService _sortService;
        private readonly ILogger<ProductSortController> _logger;

        public ProductSortController(
            ISortService sortService,
            ILogger<ProductSortController> logger)
        {
            _sortService = sortService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(SortOption sortOption)
        {
            return new JsonResult(await this._sortService.GetSortedProducts(sortOption));
        }
    }
}
