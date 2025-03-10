using MiniExcelLibs;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using PDMApp.Dtos.BasicProgram;

namespace PDMApp.Utils
{
    public class ExportExcel_MiniExcel
    {
        public byte[] ExportMasterDetailToExcel(IEnumerable<pdm_spec_headDto> masterData)
        {
            // 資料準備
            var exportData = new List<dynamic>();

            // 1. 將主檔與子檔資料組合成單一資料列
            foreach (var master in masterData)
            {
                foreach (var detail in master.pdm_Spec_ItemDtos)
                {
                    exportData.Add(new
                    {
                        Year = master.Year,
                        Season = master.Season,
                        Stage = master.Stage,
                        MoldNo = master.MoldNo,
                        Factory = master.Factory,
                        ItemNameEng = master.ItemNameEng,
                        ItemNameJpn = master.ItemNameJpn,
                        ItemNo = master.ItemNo,
                        DevNo = master.DevNo,
                        DevColorDispName = master.DevColorDispName,
                        ColorNo = master.ColorNo,
                        ActNo = detail.ActNo,
                        Parts = detail.Parts,
                        MoldNoDetail = detail.MoldNo,
                        MaterialNo = detail.MaterialNo,
                        Material = detail.Material,
                        SubMaterial = detail.SubMaterial,
                        Standard = detail.Standard,
                        Supplier = detail.Supplier,
                        Colors = detail.Colors,
                        Memo = detail.Memo,
                        Hcha = detail.Hcha,
                        Sec = detail.Sec,
                        Width = detail.Width
                    });
                }
            }
            /*
            // 1. 組合主檔與子檔資料
            var exportData = new List<Dictionary<string, object>>();

            foreach (var master in masterData)
            {
                foreach (var detail in master.pdm_Spec_ItemDtos)
                {
                    exportData.Add(new Dictionary<string, object>
                    {
                        ["YEAR"] = master.Year,
                        ["SEASON"] = master.Season,
                        ["STAGE"] = master.Stage,
                        ["MOLD_NO"] = master.MoldNo,
                        ["FACTORY"] = master.Factory,
                        ["ITEM_NAME_ENG"] = master.ItemNameEng,
                        ["ITEM_NAME_JPN"] = master.ItemNameJpn,
                        ["ITEM_NO"] = master.ItemNo,
                        ["DEV_NO"] = master.DevNo,
                        ["DEV_COLOR"] = master.DevColorDispName,
                        ["COLOR_NO"] = master.ColorNo,
                        ["PART_NO"] = detail.ActNo,
                        ["PARTS"] = detail.Parts,
                        ["MOLDNO"] = detail.MoldNo,
                        ["MATERIAL_NO"] = detail.MaterialNo,
                        ["MATERIAL"] = detail.Material,
                        ["Sub Material/Remarks"] = detail.SubMaterial,
                        ["STANDARD"] = detail.Standard,
                        ["SUPPLIER"] = detail.Supplier,
                        ["COLORS"] = detail.Colors,
                        ["MEMO"] = detail.Memo,
                        ["HC/HA"] = detail.Hcha,
                        ["SEC"] = detail.Sec,
                        ["WIDTH"] = detail.Width
                    });
                }
            }
            */
            // 2. 寫入 Excel 檔案到記憶體
            using var memoryStream = new MemoryStream();
            MiniExcel.SaveAs(memoryStream, exportData, sheetName: "SpecSearch");
            return memoryStream.ToArray();
        }
    }
}
