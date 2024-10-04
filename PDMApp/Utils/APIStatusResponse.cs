namespace PDMApp.Utils
{
    public class APIStatusResponse<T>
    {
        public T Data { get; set; } //用來接資料集的
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
    /*APIStatusResponse 狀態碼共5碼，以下說明5碼代表的意義。由左到右如下
        Ex: **10001**
        1 = TreeMenu的順序 (SPEC)
        0 = 第二分類，目前無
        0 = 十位數程式編號
        0 = 個位數程式編號
        1 = 是否有值  (0 = false；1 = true)
     */
}
