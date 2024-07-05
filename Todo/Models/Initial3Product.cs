using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Initial3Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ProductType { get; set; }
        public string DefaultUnits { get; set; }
        public string IsEnabled { get; set; }
        public string FlowPath { get; set; }
        public string UnitConversionFactors { get; set; }
        public string SubProducts { get; set; }
        public string BinningTree { get; set; }
        public string InitialUnitCost { get; set; }
        public string FinishedUnitCost { get; set; }
        public string Yield { get; set; }
        public string CycleTime { get; set; }
        public string IncludeInSchedule { get; set; }
        public string CapacityClass { get; set; }
        public string MaterialTransferMode { get; set; }
        public string MaterialTransferApprovalMode { get; set; }
        public string MaterialTransferAllowedPickup { get; set; }
        public string ProductGroup { get; set; }
        public string IsEnableForMaintenanceManagement { get; set; }
        public string MaintenanceManagementConsumeQuantity { get; set; }
        public string IsDiscrete { get; set; }
        public string MoistureSensitivityLevel { get; set; }
        public string FloorLife { get; set; }
        public string FloorLifeUnitOfTime { get; set; }
        public string RequiresApproval { get; set; }
        public string ApprovalRole { get; set; }
        public string CanSplitForPicking { get; set; }
        public string MaterialLogisticsDefaultRequestQuantity { get; set; }
        public string ConsumptionScrap { get; set; }
        public string AdditionalConsumptionQuantity { get; set; }
        public string IsEnabledForMaterialLogistics { get; set; }
        public string DataGroup { get; set; }
    }
}
