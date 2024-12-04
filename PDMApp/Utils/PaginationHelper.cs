using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } // 當前頁資料
        public int TotalCount { get; set; } // 總筆數
        public int TotalPages { get; set; } // 總頁數
        public int PageNumber { get; set; } // 當前頁碼
        public int PageSize { get; set; } // 每頁顯示數量

        public PagedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
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

            // 當前頁資料
            var items = await source
                .Skip((pageNumber - 1) * pageSize) // 跳過的資料筆數
                .Take(pageSize) // 取得的資料筆數
                .ToListAsync();

            // 回傳分頁結果
            return new PagedResult<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
