using FBM.Core.Resource;
using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Models.CastleLdrPointM
{
    public class CastleLdrPointFastAddVM
    {
        [Required]
        [Display(Name = "WallPosition", ResourceType = typeof(Resources))]
        public WallPosition WallPosition { get; set; }
        [Required]
        [Display(Name = "Station", ResourceType = typeof(Resources))]
        public Guid StationID { get; set; }

        [Required]
        [Display(Name = "Data1", ResourceType = typeof(Resources))]
        public int Data1 { get; set; }
        [Required]
        [Display(Name = "Data2", ResourceType = typeof(Resources))]
        public int Data2 { get; set; }
        [Required]
        [Display(Name = "Data3", ResourceType = typeof(Resources))]
        public int Data3 { get; set; }
        [Required]
        [Display(Name = "Data4", ResourceType = typeof(Resources))]
        public int Data4 { get; set; }
        [Required]
        [Display(Name = "Data5", ResourceType = typeof(Resources))]
        public int Data5 { get; set; }
        [Required]
        [Display(Name = "Data6", ResourceType = typeof(Resources))]
        public int Data6 { get; set; }
        [Required]
        [Display(Name = "Data7", ResourceType = typeof(Resources))]
        public int Data7 { get; set; }
        [Required]
        [Display(Name = "Data8", ResourceType = typeof(Resources))]
        public int Data8 { get; set; }
        [Required]
        [Display(Name = "Data9", ResourceType = typeof(Resources))]
        public int Data9 { get; set; }
        [Required]
        [Display(Name = "Data10", ResourceType = typeof(Resources))]
        public int Data10 { get; set; }
        [Required]
        [Display(Name = "Data11", ResourceType = typeof(Resources))]
        public int Data11 { get; set; }
        [Required]
        [Display(Name = "Data12", ResourceType = typeof(Resources))]
        public int Data12 { get; set; }
        [Required]
        [Display(Name = "Data13", ResourceType = typeof(Resources))]
        public int Data13 { get; set; }
    }
}