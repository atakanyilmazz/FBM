using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Enum;
using System.ComponentModel.DataAnnotations;
using FBM.Core.Resource;

namespace FBM.Data.Entity.Station
{
    public class Ldr : BaseEntity
    {
        [Required]
        [Display(Name = "Station", ResourceType = typeof(Resources))]
        public Guid StationId { get; set; }
        [Required]
        [Display(Name = "Axis", ResourceType = typeof(Resources))]
        public Axis Axis { get; set; }
        [Required]
        [Display(Name = "WallPosition", ResourceType = typeof(Resources))]
        public WallPosition WallPosition { get; set; }
        [Display(Name = "LdrUnitNo", ResourceType = typeof(Resources))]
        public int LdrUnitNo { get; set; }
        [Display(Name = "AxisOrder", ResourceType = typeof(Resources))]
        public int AxisOrder { get; set; }
        [Display(Name = "LaserCount", ResourceType = typeof(Resources))]
        public int LaserCount { get; set; }
        /// <summary>
        /// Bağlantılar
        /// </summary>
        [Display(Name = "Station", ResourceType = typeof(Resources))]
        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
    }
}