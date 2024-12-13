using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Results { get; set; } // 當前頁資料

        public class PaginationInfo
        {
            public int TotalCount { get; set; } // 總筆數
            public int TotalPages { get; set; } // 總頁數
            public int PageNumber { get; set; } // 當前頁碼
            public int PageSize { get; set; } // 每頁顯示數量
        }

        public PaginationInfo Pagination { get; set; } // 分頁資訊

        public PagedResult(IEnumerable<T> results, int totalCount, int pageNumber, int pageSize)
        {
            Results = results ?? Enumerable.Empty<T>();

            int totalPages = PaginationHelper.CalculateTotalPages(totalCount, pageSize);
            var (cpageNumber, cpageSize) = PaginationHelper.ValidatePagination(pageNumber, pageSize, totalPages);

            Pagination = new PaginationInfo
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PageNumber = cpageNumber,
                PageSize = cpageSize
            };
        }
    }


    public static class PaginationHelper
    {
        private const int DefaultPageSize = 10;

        public static int CalculateTotalPages(int totalCount, int pageSize)
        {
            if (pageSize <= 0) pageSize = DefaultPageSize;
            return (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static (int CorrectedPageNumber, int PageSize) ValidatePagination(int pageNumber, int pageSize, int totalPages)
        {
            if (pageSize <= 0) pageSize = DefaultPageSize;
            if (pageNumber > totalPages)
            {
                pageNumber = totalPages > 0 ? totalPages : 1;
            }
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            return (pageNumber, pageSize);
        }

        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            var totalCount = await source.CountAsync();
            int totalPages = CalculateTotalPages(totalCount, pageSize);

            var (cpageNumber, cpageSize) = ValidatePagination(pageNumber, pageSize, totalPages);

            var results = await source
                .Skip((cpageNumber - 1) * cpageSize)
                .Take(cpageSize)
                .ToListAsync();

            return new PagedResult<T>(results, totalCount, cpageNumber, cpageSize);
        }
    }

}
