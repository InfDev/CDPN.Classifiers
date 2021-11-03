using Gridify;
using CDPN.Common.Wrappers;

namespace CDPN.Common.Extensions
{
    public static class GridifyExtensions
    {
        public static WidePaging<T> WidePaging<T>(this Paging<T> paging, GridifyQuery gQuery)
        {
            var pageNumber = gQuery.Page <= 0 ? 1 : gQuery.Page;
            var pageSize = gQuery.PageSize <= 0 ? 20 : gQuery.PageSize;
            var totalRecords = paging.Count;
            var totalPages = ((double)totalRecords / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            return new WidePaging<T>(
                pageNumber: pageNumber,
                pageSize: pageSize,
                totalRecords: totalRecords,
                totalPages: roundedTotalPages,
                data: paging.Data);
        }

    }
}
