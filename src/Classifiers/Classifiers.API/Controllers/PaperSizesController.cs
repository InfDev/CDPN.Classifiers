using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDPN.Classifiers.Entities;
using CDPN.Classifiers.Infrastructure.Data;
using CDPN.Common.ViewModels;
using Gridify.EntityFramework;
using CDPN.Common.Wrappers;
using CDPN.Common.Extensions;
using Gridify;

namespace CDPN.Classifiers.API.Controllers
{
    /// <summary>
    /// Размеры бумаги и конвертов
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaperSizesController : ControllerBase
    {
#pragma warning disable CS1573 // Параметр не имеет соответствующий тег параметра в комментарии XML (в отличие от остальных параметров)
#pragma warning disable CS1572 // Комментарий XML содержит тег param, но параметр с таким именем не существует

        private readonly ClassifiersContext _dbContext;
        public PaperSizesController(ClassifiersContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Размеры бумаги и конвертов постранично с возможностями сортировки и фильтрации
        /// </summary>
        /// <param name="Page">Номер страницы</param>
        /// <param name="PageSize">Размер страницы</param>
        /// <param name="OrderBy">Сортировка</param>
        /// <param name="Filter">Фильтр</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PaperSize>), (int)HttpStatusCode.OK)]
        public async Task<WidePaging<PaperSize>> GetPaperSizes([FromQuery] GridifyQuery gQuery)
        {
            var pagingResult = await _dbContext.PaperSizes.GridifyAsync(gQuery);
            return pagingResult.WidePaging(gQuery);
        }
    }
}
