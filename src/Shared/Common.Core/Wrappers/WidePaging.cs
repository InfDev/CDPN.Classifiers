using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPN.Common.Wrappers
{
    public class WidePaging<T> : IWidePaging<T>
    {
        public WidePaging()
        {
            Data = Enumerable.Empty<T>();
        }

        public WidePaging(int pageNumber, int pageSize, 
            int totalPages, int totalRecords, IEnumerable<T> data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
