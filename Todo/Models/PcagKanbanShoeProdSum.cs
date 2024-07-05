using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PcagKanbanShoeProdSum
    {
        public string Factory { get; set; }
        public string ProdType { get; set; }
        public string Lineid { get; set; }
        public string ProdQuantity { get; set; }
        public string ProdTypeName { get; set; }
    }
}
