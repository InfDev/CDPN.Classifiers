﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPN.Common.Wrappers
{
    public interface IWidePaging<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}