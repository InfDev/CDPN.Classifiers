using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPN.Classifiers.Client.Models
{
    public class PagingRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string OrderBy { get; set; }
        public string Filter { get; set; }
    }
}
