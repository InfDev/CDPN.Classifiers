using Microsoft.AspNetCore.Mvc;
using CDPN.Classifiers.Entities;
using CDPN.Classifiers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CDPN.Common.ViewModels;

namespace CDPN.Classifiers.API.Controllers
{
    /// <summary>
    /// Валюта по ISO 4217
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ClassifiersContext _dbContext;
        public CurrencyController(ClassifiersContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Весь список валют
        /// </summary>
        /// <param name="ge_group">С группой равной или более</param>
        /// <returns></returns>
        [HttpGet("items")]
        [ProducesResponseType(typeof(List<Currency>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Currency>>> CurrencyItems(int? ge_group = 0)
        {
            return await _dbContext.Currencies.Where(ci => ci.Group >= ge_group).ToListAsync();
        }

        /// <summary>
        /// Валюты с указанными идентификаторами по ISO 4217 alphabetic code
        /// </summary>
        /// <param name="ids">Идентификаторы</param>
        /// <returns></returns>
        [HttpGet("items/by_ids")]
        [ProducesResponseType(typeof(List<Currency>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Currency>>> CurrencyItemsByIds([FromQuery] string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var extIds = ids.ToUpper().Split(',').Select(id => (Ok: id.Length == 3, Value: id));
                if (extIds.All(eid => eid.Ok))
                {
                    var selectIds = extIds.Select(eid => eid.Value);
                    var items = await _dbContext.Currencies.Where(ci => selectIds.Contains(ci.Id)).ToListAsync();   
                    return Ok(items);
                }
            }
            return BadRequest("Неприпустиме значення ідентифікаторів. Має бути список 3-символьних ідентифікаторів, розділених комами");
        }

        /// <summary>
        /// Валюты с указанными кодами по ISO 4217 numeric code
        /// </summary>
        /// <param name="codes">3-х символьные коды</param>
        /// <returns></returns>
        [HttpGet("items/by_codes")]
        [ProducesResponseType(typeof(List<Currency>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Currency>>> CurrencyItemsByCodes([FromQuery] string codes)
        {
            if (!string.IsNullOrEmpty(codes))
            {
                var extCodes = codes.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));
                if (extCodes.All(eid => eid.Ok))
                {
                    var selectCodes = extCodes.Select(eid => eid.Value);
                    var items = await _dbContext.Currencies.Where(ci => selectCodes.Contains(ci.NumericCode)).ToListAsync();
                    return Ok(items);
                }
            }
            return BadRequest("Неприпустиме значення кодів. Має бути список цілих чисел, розділених комами");
        }

        /// <summary>
        /// Cписок валют по строке поиска в Id и Name
        /// </summary>
        /// <param name="search">Строка поиска</param>
        /// <returns></returns>
        [HttpGet("items/by_search")]
        [ProducesResponseType(typeof(List<Currency>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Currency>>> CurrencyItemsSearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var pattern = $"%{search}%";
                return await _dbContext.Currencies.Where(ci =>
                    EF.Functions.Like(ci.Id, pattern) ||
                    EF.Functions.Like(ci.Name, pattern)).ToListAsync();
            }
            return BadRequest("Не визначено рядок пошуку");
        }

        /// <summary>
        /// Валюты постранично
        /// </summary>
        /// <param name="ge_group">С группой равной или более</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageIndex">Индекс страницы</param>
        /// <returns></returns>
        [HttpGet("items/by_page")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Currency>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<Currency>>> ItemsAsync(
            [FromQuery] int ge_group = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 0)
        {
            var query = (IQueryable<Currency>)_dbContext.Currencies;

            if (ge_group > 0)
            {
                query = query.Where(ci => ci.Group >= ge_group);
            }

            var totalItems = await query
                .CountAsync();

            var itemsOnPage = await query
                .OrderBy(item => item.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItemsViewModel<Currency>(pageIndex, pageSize, totalItems, itemsOnPage);
        }
    }
}
