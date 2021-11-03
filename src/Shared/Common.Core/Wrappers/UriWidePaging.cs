
namespace CDPN.Common.Wrappers
{
    public class UriWidePaging<T> : IWidePaging<T>
    {
        public UriWidePaging()
        {
            Data = Enumerable.Empty<T>();
        }

        public UriWidePaging(int pageNumber, int pageSize,
            int totalPages, int totalRecords, IEnumerable<T> data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        }

        public UriWidePaging(WidePaging<T> paging)
        {
            PageNumber = paging.PageNumber;
            PageSize = paging.PageSize;
            TotalPages = paging.TotalPages;
            TotalRecords = paging.TotalRecords;
            Data = paging.Data;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
