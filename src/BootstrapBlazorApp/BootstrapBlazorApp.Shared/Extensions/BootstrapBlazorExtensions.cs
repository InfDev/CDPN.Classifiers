using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using CDPN.Classifiers.Client.Models;

namespace BootstrapBlazorApp.Shared.Extensions
{
    public static class BootstrapBlazorExtensions
    {
        // https://alirezanet.github.io/Gridify/

        private static Dictionary<FilterAction, string> _gridifyFilterActions = new Dictionary<FilterAction, string>
            {
                { FilterAction.Equal, "=" },
                { FilterAction.NotEqual, "!=" },
                { FilterAction.GreaterThan, ">" },
                { FilterAction.GreaterThanOrEqual, ">=" },
                { FilterAction.LessThan, "<" },
                { FilterAction.LessThanOrEqual, "<=" },
                { FilterAction.Contains, "=*" },
                { FilterAction.NotContains, "!*" },
                { FilterAction.CustomPredicate, null }
            };
        private static Dictionary<FilterLogic, string> _gridifyFilterLogics = new Dictionary<FilterLogic, string>
            {
                { FilterLogic.And, "," },
                { FilterLogic.Or, "|" }
            };


        public static PagingRequest PagingRequest(this QueryPageOptions options)
        {
            var request = new PagingRequest {
                Page = options.PageIndex,
                PageSize = options.PageItems
            };
            if (!string.IsNullOrEmpty(options.SortName))
            {
                request.OrderBy = options.SortName;
                if (options.SortOrder == SortOrder.Desc)
                    request.OrderBy += " desc";
            }
            if (options.Filters.Any())
            {
                var filterBuilder = new StringBuilder();
                var isFirstFilter = true;
                foreach(var filter in options.Filters)
                {
                    if (!isFirstFilter)
                        filterBuilder.Append(",");
                    filterBuilder.Append("(");
                    var isFirstCondition = true;
                    foreach (var condition in filter.GetFilterConditions())
                    {
                        if (!isFirstCondition)
                            filterBuilder.Append(_gridifyFilterLogics[condition.FilterLogic]);
                        filterBuilder.Append($"{condition.FieldKey}{_gridifyFilterActions[condition.FilterAction]}{condition.FieldValue}");
                        isFirstCondition = false;
                    }
                    filterBuilder.Append(")");
                    isFirstFilter = false;
                }
                request.Filter = filterBuilder.ToString();
            }
            return request;
        }
    }
}
