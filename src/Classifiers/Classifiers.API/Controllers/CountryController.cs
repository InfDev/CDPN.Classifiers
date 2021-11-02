using Microsoft.AspNetCore.Mvc;
using CDPN.Classifiers.Entities;
using CDPN.Classifiers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CDPN.Common.ViewModels;

namespace CDPN.Classifiers.API.Controllers
{
    /// <summary>
    /// Страна по ISO 3166-1
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ClassifiersContext _dbContext;
        public CountryController(ClassifiersContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Весь список стран
        /// </summary>
        /// <param name="ge_group">С группой равной или более</param>
        /// <returns></returns>
        [HttpGet("items")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Country>>> CountryItems(int? ge_group = 0)
        {
            return await _dbContext.Countries.Where(ci => ci.Group >= ge_group).ToListAsync();
        }

        /// <summary>
        /// Страны с указанными идентификаторами по ISO 3166-1 alpha2
        /// </summary>
        /// <param name="ids">Идентификаторы</param>
        /// <returns></returns>
        [HttpGet("items/by_ids")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Country>>> CountryItemsByIds([FromQuery] string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var extIds = ids.ToUpper().Split(',').Select(id => (Ok: id.Length == 2, Value: id));
                if (extIds.All(eid => eid.Ok))
                {
                    var selectIds = extIds.Select(eid => eid.Value);
                    var items = await _dbContext.Countries.Where(ci => selectIds.Contains(ci.Id)).ToListAsync();   
                    return Ok(items);
                }
            }
            return BadRequest("Неприпустиме значення ідентифікаторів. Має бути список 2-символьних ідентифікаторів, розділених комами");
        }

        /// <summary>
        /// Страны с указанными кодами по ISO 3166-1 alpha3
        /// </summary>
        /// <param name="ids">Идентификаторы</param>
        /// <returns></returns>
        [HttpGet("items/by_alpha3s")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Country>>> CountryItemsByAlpha3([FromQuery] string alpha3s)
        {
            if (!string.IsNullOrEmpty(alpha3s))
            {
                var extalpha3 = alpha3s.ToUpper().Split(',').Select(a => (Ok: a.Length == 3, Value: a));
                if (extalpha3.All(eid => eid.Ok))
                {
                    var selectAlpha3s = extalpha3.Select(a => a.Value);
                    var items = await _dbContext.Countries.Where(ci => selectAlpha3s.Contains(ci.Alpha3)).ToListAsync();
                    return Ok(items);
                }
            }
            return BadRequest("Неприпустиме значення кодів. Має бути список 3-символьних кодів, розділених комами");
        }


        /// <summary>
        /// Страны с указанными кодами по ISO 3166-1 numeric code
        /// </summary>
        /// <param name="codes">3-х символьные коды</param>
        /// <returns></returns>
        [HttpGet("items/by_codes")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Country>>> CountryItemsByCodes([FromQuery] string codes)
        {
            if (!string.IsNullOrEmpty(codes))
            {
                var extCodes = codes.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));
                if (extCodes.All(eid => eid.Ok))
                {
                    var selectCodes = extCodes.Select(eid => eid.Value);
                    var items = await _dbContext.Countries.Where(ci => selectCodes.Contains(ci.NumericCode)).ToListAsync();
                    return Ok(items);
                }
            }
            return BadRequest("Неприпустиме значення кодів. Має бути список цілих чисел, розділених комами");
        }

        /// <summary>
        /// Cписок стран по строке поиска в Id, Alpha3 и Name
        /// </summary>
        /// <param name="search">Строка поиска</param>
        /// <returns></returns>
        [HttpGet("items/by_search")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<Country>>> CountryItemsSearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var pattern = $"%{search}%";
                return await _dbContext.Countries.Where(ci =>
                    EF.Functions.Like(ci.Id, pattern) ||
                    EF.Functions.Like(ci.Alpha3, pattern) ||
                    EF.Functions.Like(ci.Name, pattern)).ToListAsync();
            }
            return BadRequest("Не визначено рядок пошуку");
        }

        /// <summary>
        /// Страны постранично
        /// </summary>
        /// <param name="ge_group">С группой равной или более</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageIndex">Индекс страницы</param>
        /// <returns></returns>
        [HttpGet("items/by_page")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Country>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<Country>>> ItemsAsync(
            [FromQuery] int ge_group = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 0)
        {
            var query = (IQueryable<Country>)_dbContext.Countries;

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

            return new PaginatedItemsViewModel<Country>(pageIndex, pageSize, totalItems, itemsOnPage);
        }
    }
}
