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
        /*APIStatusResponse 狀態碼共5碼，以下說明5碼代表的意義。由左到右如下
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
    }
}
