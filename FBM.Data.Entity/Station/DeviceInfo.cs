using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Entity.Station;

namespace FBM.Data.Entity.Station
{
    public class DeviceInfo : BaseEntity
    {
        [Required]
        [Display(Name = "LdrCount", ResourceType = typeof(Resources))]
        public int LdrCount { get; set; }
        [Required]
        [Display(Name = "DeviceCount", ResourceType = typeof(Resources))]
        public int DeviceCount { get; set; }
    }
}
