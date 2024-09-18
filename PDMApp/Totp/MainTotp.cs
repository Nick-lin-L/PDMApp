using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using OtpNet;
using QRCoder;

namespace PDMApp.Totp
{
    public class MainTotp
    {
        public static void RunTop(string[] args)
        {
            var secret = KeyGeneration.GenerateRandomKey();
            var sd = new SecretData
            {
                Issuer = "Darkthread",
                Label = "TOTP測試",
                Secret = Base32Encoding.ToString(secret)
            };
            //產生 QRCode
            //補充說明：此處為求簡便寫成暫存檔以瀏覽器開啟，實際應用時宜全程於記憶體處理資料不落地
            //並於網頁顯示完即銷毀，勿以 Email 或其他方傳遞，以降低外流風險
            var qrCodeImgFile = System.IO.Path.GetTempFileName() + ".png";
            sd.GenQRCode().Save(qrCodeImgFile, System.Drawing.Imaging.ImageFormat.Png);
            //使用預設圖片檢視軟體開啟
            var p = Process.Start(new ProcessStartInfo()
            {
                FileName = $"file:///{qrCodeImgFile}",
                UseShellExecute = true
            });
            while (true)
            {
                Console.WriteLine("輸入一次性密碼進行驗證，或直接按 Enter 結束");
                var pwd = Console.ReadLine();
                if (string.IsNullOrEmpty(pwd)) break;
                Console.WriteLine(" " + sd.ValidateTotp(pwd));
            }
        }
    }
    public class SecretData
    {
        public string Issuer { get; set; }
        public string Label { get; set; }
        public string Secret { get; set; }
        public string GenQRCodeUrl() =>
            $"otpauth://totp/{Label}?issuer={Uri.EscapeDataString(Issuer)}&secret={Uri.EscapeDataString(Secret)}";

        public Bitmap GenQRCode()
        {
            var qrcg = new QRCodeGenerator();
            var data = qrcg.CreateQrCode(GenQRCodeUrl(), QRCodeGenerator.ECCLevel.Q);
            var qrc = new QRCode(data);
            return qrc.GetGraphic(20);
        }

        OtpNet.Totp totpInstance = null;
        public string ValidateTotp(string totp)
        {
            if (totpInstance == null)
            {
                totpInstance = new OtpNet.Totp(Base32Encoding.ToBytes(Secret));
            }
            long timedWindowUsed;
            if (totpInstance.VerifyTotp(totp, out timedWindowUsed))
            {
                return $"驗證通過 - {timedWindowUsed}";
            }
            else
            {
                return "驗證失敗";
            }
        }
    }
}
