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
    public class CastleLdrPoint : BaseEntity
    {
        [Required]
        [Display(Name = "Castle", ResourceType = typeof(Resources))]
        public Guid CastleId { get; set; }
        [Required]
        [Display(Name = "Axis", ResourceType = typeof(Resources))]
        public Axis Axis { get; set; }
        [Required]
        [Display(Name = "StartPoint", ResourceType = typeof(Resources))]
        public int StartPoint { get; set; }
        [Required]
        [Display(Name = "EndPoint", ResourceType = typeof(Resources))]
        public int EndPoint { get; set; }
        /// <summary>
        /// Bağlantılar
        /// </summary>
        [ForeignKey("CastleId")]
        public virtual Castle Castle { get; set; }
        
    }
}
