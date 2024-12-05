﻿using Microsoft.AspNetCore.Mvc;
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
         * 1 = TreeMenu的順序 (SPEC)
         * 0 = 第二分類，目前無
         * 0 = 十位數程式編號
         * 0 = 個位數程式編號
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
        private static ActionResult<APIStatusResponse<T>> GenerateApiResponse<T>(string errorCode, string message, T data)
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
            var totalPages = data.Count;
            var nonEmptyPages = data.Count(kv => kv.Value is IEnumerable<object> collection && collection.Any());

            if (nonEmptyPages == 0)
            {
                return GenerateApiResponse<IDictionary<string, object>>(emptyCode, DefaultEmptyMessage, new Dictionary<string, object>());
            }
            else if (nonEmptyPages == totalPages)
            {
                return GenerateApiResponse<IDictionary<string, object>>(successCode, string.Empty, data);
            }
            else
            {
                return GenerateApiResponse<IDictionary<string, object>>(partialCode, "資料集缺少", data);
            }
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
