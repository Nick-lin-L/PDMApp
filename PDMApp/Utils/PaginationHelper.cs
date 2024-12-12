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
            Results = results;
            Pagination = new PaginationInfo
            {
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

    }

    public static class PaginationHelper
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
            this IQueryable<T> source, 
            int pageNumber,
            int pageSize)
        {
            // 總筆數
            var totalCount = await source.CountAsync();

            // 計算總頁數
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // 如果 pageNumber 超過總頁數，強制調整為最後一頁
            if (pageNumber > totalPages)
            {
                pageNumber = totalPages > 0 ? totalPages : 1; // 確保至少有一頁
            }

            // 如果 pageNumber 小於 1，強制調整為第一頁
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            // 當前頁資料
            var results = await source
                .Skip((pageNumber - 1) * pageSize) // 跳過的資料筆數
                .Take(pageSize) // 取得的資料筆數
                .ToListAsync();

            // 回傳分頁結果
            return new PagedResult<T>(results, totalCount, pageNumber, pageSize);
        }
    }
}
