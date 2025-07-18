﻿using PDMApp.Utils.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDMApp.Dtos.SPEC
{
    public class CustomerSearchDto
    {
        public string? Season { get; set; }
        public string? WorkingName { get; set; }
        public string? Stage { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? DevelopmentColor { get; set; }
        public string? ColorCode { get; set; }
        public string? Colorway { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? CreateDate { get; set; } 
        public string? CreateUser { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? LastUpdate { get; set; }
        public string? LoginFactory { get; set; }
    }
}
