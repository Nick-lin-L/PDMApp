using PDMApp.Utils.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class ShoeShapeImportHeadParameter
    {
        public string Product_M_Id { get; set; }
        [JsonConverter(typeof(BoolToStringConverter))]
        public bool Active { get; set; }
        public string Assigned_Agents { get; set; }
        public string Working_Name { get; set; }
        public string Series { get; set; }
        public string Series_With_Generation { get; set; }
        public string Development_No { get; set; }
        public string Item_Initial_Season { get; set; }
        public string Item_Mode { get; set; }
        public string Item_Mode_Sub_Type { get; set; }
        public string Article_Description { get; set; }
        public string Gender { get; set; }
        public string Kids_Type { get; set; }
        public string Width { get; set; }
        public string Pack { get; set; }
        public string LP01_Factory_Season_Forecast { get; set; }
        public string LP02_Factory_Season_Forecast { get; set; }
        public string LP03_Factory_Season_Forecast { get; set; }
        public string LP01_Factory_Yearly_Forecast { get; set; }
        public string LP02_Factory_Yearly_Forecast { get; set; }
        public string LP03_Factory_Yearly_Forecast { get; set; }
        [JsonConverter(typeof(BoolToStringConverter))]
        public string Silver_Flag { get; set; }
        public string Account_Code { get; set; }
        public string Account_Name { get; set; }
        public string Account_Exclusivity { get; set; }
        public string Region_Exclusivity { get; set; }
        [JsonConverter(typeof(BoolToStringConverter))]
        public string Regional_SMU_Team_Approval { get; set; }
        public string Stage { get; set; }
        public string Latest_BOM { get; set; }
        public string Mold_Set { get; set; }
        public string Last1 { get; set; }
        public string Last2 { get; set; }
        public string Last3 { get; set; }
        public string SizeMap { get; set; }
        public string Lasting { get; set; }
        public string Heel_Height { get; set; }
        public string Size_Range { get; set; }
        public string Size_Run { get; set; }
        public string Default_Size { get; set; }
        public string PM_Name { get; set; }
        public string Developer { get; set; }
        public string Designer { get; set; }
        public string Developer_Remarks { get; set; }
        public string Global_RID { get; set; }
        public string Earliest_RID { get; set; }
        public string Production_Start_Month { get; set; }
        public string TDM_Date { get; set; }
        public string SFM_Date { get; set; }
        public string Production_Lead_Time { get; set; }
        [JsonConverter(typeof(BoolToStringConverter))]
        public string Production_Approval { get; set; }
        public string Production_Approval_Date { get; set; }
        public string MOQ_Per_Item { get; set; }
        public string Sampling_Factory { get; set; }
        public string Main_Factory { get; set; }
        public string Sub_Factory { get; set; }
        public string Sub_Factory2 { get; set; }
        public string Original_Factory { get; set; }
        public string Previous_Factory { get; set; }
        public string Transfer_To { get; set; }
        public string Sourcing_Remarks { get; set; }
        public string Upper_Material { get; set; }
        public string Upper_Material1 { get; set; }
        public string Upper_Material2 { get; set; }
        public string Upper_Material3 { get; set; }
        public string Upper_Material4 { get; set; }
        public string Upper_Material5 { get; set; }
        public string Sole_Material1 { get; set; }
        public string Sole_Material2 { get; set; }
        public string Sole_Material3 { get; set; }
        public string Cleats_Type { get; set; }
        public string Cleats_Material { get; set; }
        public string Cleats_Replaceable_Fixed { get; set; }
        public string Domain { get; set; }
        public string Brand { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string Silo1 { get; set; }
        public string Silo2 { get; set; }
        public string LS_Category { get; set; }
        public string Product_Line_Type { get; set; }
        public string Distribution_Tier { get; set; }
        public string Price_Tier { get; set; }
        public string Global_SRP { get; set; }
        [JsonConverter(typeof(BoolToStringConverter))]
        public string Key_Item { get; set; }
        public string Target_Of_Colors { get; set; }
        public string Jump_To_Merch_Plan { get; set; }
        public string Ref_Item { get; set; }
        public string Ref_Item_Mold_Set { get; set; }
        public string MD_Remarks { get; set; }

        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? Modified { get; set; }
        public string Modified_By { get; set; }
        public string Pushed_Development_Time { get; set; }
        public string Item_Trading_Code { get; set; }
        public string Global_ID { get; set; }
        public string Sort_Order { get; set; }
        public string Login_Factory { get; set; }
    }

    public class ShoeShapeImportDetailParameter
    {
        //public string Product_M_Id { get; set; }
        public string Development_No { get; set; }

        public string Product_D_Id { get; set; }
        public bool Deteail_Active { get; set; }
        public string Design_Candidate { get; set; }
        public string Colorway { get; set; }
        public string Development_Color_No { get; set; }
        public string Color_Code { get; set; }
        public string Main_Color { get; set; }
        public string Sub_Color { get; set; }
        public string Moq_Per_Color { get; set; }
    }
}