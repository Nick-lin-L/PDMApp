using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PDMApp.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PDMApp.Utils
{
    public class APIStatusResponse<T>
    {
        public T Data { get; set; } // 用來接資料集的
        public string ErrorCode { get; set; }
        public string Message { get; set; }

        /* APIStatusResponse 狀態碼共5碼
         * 以下說明5碼代表的意義。由左到右如下
         * Ex: **10001**
         * 1 = TreeMenu的順序 1 = SPEC
         *                   2 = CBD
         *                   3 = FactorySPEC
         *                   4 = PLM
         *                   5 = PGTSPEC
         * 0 = 第二分類，目前無
         * 0 = 十位數程式編號，目前無
         * 0 = 個位數程式編號，目前無
         * 1 = 是否有值  (0 = false；1 = true)
         */
    }

    public static class APIResponseHelper
    {
        // 預設的狀態碼
        private const string DefaultSuccessCode = "OK";
        private const string DefaultEmptyCode = "10000";
        private const string DefaultPartialCode = "10002";
        private const string DefaultErrorCode = "50000";
        private const string DefaultErrorMessage = "伺服器處理錯誤，請稍後再試。";
        private const string DefaultEmptyMessage = "查無資料";

        // 私有方法：生成統一格式的 API 回應
        public static ActionResult<APIStatusResponse<T>> GenerateApiResponse<T>(string errorCode, string message, T data)
        {
            return new OkObjectResult(new APIStatusResponse<T>
            {
                ErrorCode = errorCode,
                Message = message,
                Data = data
            });
        }

        // 處理正常 API 回應
        public static ActionResult<APIStatusResponse<IEnumerable<T>>> HandleApiResponse<T>(IEnumerable<T> data, string successCode = DefaultSuccessCode, string emptyCode = DefaultEmptyCode)
        {
            if (data == null || !data.Any())
            {
                return GenerateApiResponse<IEnumerable<T>>(emptyCode, DefaultEmptyMessage, Enumerable.Empty<T>());
            }

            return GenerateApiResponse<IEnumerable<T>>(successCode, string.Empty, data);
        }

        // 處理多頁回應
        public static ActionResult<APIStatusResponse<MultiPageResultDTO>> HandleMultiPageResponse(
            MultiPageResultDTO data,
            string successCode = DefaultSuccessCode,
            string emptyCode = DefaultEmptyCode)
        {
            // 檢查是否所有頁面都是空的
            if (data == null || (data.BasicData == null && data.UpperData == null))
            {
                return GenerateApiResponse<MultiPageResultDTO>(emptyCode, DefaultEmptyMessage, null);
            }

            // 正常返回多頁結果
            return GenerateApiResponse<MultiPageResultDTO>(successCode, string.Empty, data);
        }

        // 處理動態多頁回應
        public static ActionResult<APIStatusResponse<IDictionary<string, object>>> HandleDynamicMultiPageResponse(
            IDictionary<string, object> data,
            string successCode = DefaultSuccessCode,
            string emptyCode = DefaultEmptyCode,
            string partialCode = DefaultPartialCode)
        {
            bool hasEmptyCollection = false;
            bool allEmpty = true;

            foreach (var kv in data)
            {
                if (IsCollectionEmpty(kv.Value))
                {
                    hasEmptyCollection = true;
                }
                else
                {
                    allEmpty = false;
                }
            }
            if (allEmpty)
            {
                return GenerateApiResponse<IDictionary<string, object>>(emptyCode, DefaultEmptyMessage, new Dictionary<string, object>());
            }
            if (hasEmptyCollection)
            {
                return GenerateApiResponse<IDictionary<string, object>>(partialCode, "資料集缺少", data);
            }
            return GenerateApiResponse<IDictionary<string, object>>(successCode, string.Empty, data);
        }

        private static bool IsCollectionEmpty(object value)
        {
            if (value == null)
            {
                return false;
            }

            // 檢查是否為集合且有內容
            if (value is IEnumerable<object> collection)
            {
                return !collection.Any();
            }

            // 檢查 Dictionary 是否為空 (適用於 {})
            if (value is IDictionary<string, object> dict)
            {
                return !dict.Any();
            }

            // 檢查 JArray 或 JObject 是否為空
            if (value is JArray jArray)
            {
                return jArray.Count == 0;
            }
            if (value is JObject jObject)
            {
                return !jObject.HasValues;
            }

            // 其他非集合類型視為非空
            return false;
        }



        // 處理錯誤的通用方法
        public static ActionResult<APIStatusResponse<T>> HandleApiError<T>(
            string errorCode = DefaultErrorCode,
            string message = DefaultErrorMessage,
            T data = default)
        {
            return GenerateApiResponse<T>(errorCode, message, data);
        }

        public static ActionResult<APIStatusResponse<PagedResult<T>>> HandlePagedApiResponse<T>(
            PagedResult<T> paginatedResult,
            string successCode = DefaultSuccessCode,
            string emptyCode = DefaultEmptyCode)
        {
            if (paginatedResult == null || paginatedResult.Results == null || !paginatedResult.Results.Any())
            {
                return GenerateApiResponse<PagedResult<T>>(
                    emptyCode,
                    DefaultEmptyMessage,
                    new PagedResult<T>(
                        Enumerable.Empty<T>(),
                        totalCount: 0,
                        pageNumber: 1,
                        pageSize: 10));
            }

            return GenerateApiResponse<PagedResult<T>>(successCode, string.Empty, paginatedResult);
        }




    }
}
