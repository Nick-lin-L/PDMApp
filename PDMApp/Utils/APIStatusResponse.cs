using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PDMApp.Utils
{
    public class APIStatusResponse<T>
    {
        public T Data { get; set; } //用來接資料集的
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        /*APIStatusResponse 狀態碼共5碼
         * 以下說明5碼代表的意義。由左到右如下
            Ex: **10001**
            1 = TreeMenu的順序 (SPEC)
            0 = 第二分類，目前無
            0 = 十位數程式編號
            0 = 個位數程式編號
            1 = 是否有值  (0 = false；1 = true)
        */
    }
    public static class APIResponseHelper
    {
        public static ActionResult<APIStatusResponse<IEnumerable<T>>> HandleApiResponse<T>(IEnumerable<T> data, string successCode = "10001", string emptyCode = "10000")
        {
            if (data == null || !data.Any())
            {
                return new OkObjectResult(new APIStatusResponse<IEnumerable<T>>
                {
                    ErrorCode = emptyCode,
                    Message = "查無資料",
                    Data = Enumerable.Empty<T>()
                });
            }

            return new OkObjectResult(new APIStatusResponse<IEnumerable<T>>
            {
                ErrorCode = successCode,
                Message = "成功取得資料",
                Data = data
            });
        }


        public static ActionResult<APIStatusResponse<MultiPageResultDTO>> HandleMultiPageResponse(
            MultiPageResultDTO data,
            string successCode = "10001",
            string emptyCode = "10000")
        {
            // 檢查是否所有頁面都是空的
            if (data == null ||
                (data.BasicData == null && data.UpperData == null /* 檢查其他頁面 */))
            {
                return new OkObjectResult(new APIStatusResponse<MultiPageResultDTO>
                {
                    ErrorCode = emptyCode,
                    Message = "查無資料",
                    Data = null
                });
            }

            // 正常返回多頁結果
            return new OkObjectResult(new APIStatusResponse<MultiPageResultDTO>
            {
                ErrorCode = successCode,
                Message = "成功取得資料",
                Data = data
            });
        }

        public static ActionResult<APIStatusResponse<IDictionary<string, object>>> HandleDynamicMultiPageResponse(
        IDictionary<string, object> data,
        string successCode = "10001",
        string emptyCode = "10000",
        string partialCode = "10002")
        {
            // 檢查資料狀態
            var totalPages = data.Count;
            var nonEmptyPages = data.Count(kv => kv.Value is IEnumerable<object> collection && collection.Any());

            if (nonEmptyPages == 0)
            {
                // 全部沒資料
                return new OkObjectResult(new APIStatusResponse<IDictionary<string, object>>
                {
                    ErrorCode = emptyCode,
                    Message = "查無資料",
                    Data = new Dictionary<string, object>()
                });
            }
            else if (nonEmptyPages == totalPages)
            {
                // 全部有資料
                return new OkObjectResult(new APIStatusResponse<IDictionary<string, object>>
                {
                    ErrorCode = successCode,
                    Message = "成功取得資料",
                    Data = data
                });
            }
            else
            {
                // 部分有資料，部分沒資料
                return new OkObjectResult(new APIStatusResponse<IDictionary<string, object>>
                {
                    ErrorCode = partialCode,
                    Message = "資料集缺少",
                    Data = data
                });
            }
        }


    }
}
