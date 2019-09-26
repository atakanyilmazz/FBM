using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Enum;
using FBM.Data.Entity.Train;
using System.ComponentModel.DataAnnotations;
using FBM.Core.Resource;

namespace FBM.Data.Entity.Station
{
    public class Castle : BaseEntity
    {
        [Required]
        [Display(Name = "Station", ResourceType = typeof(Resources))]
        public Guid StationId { get; set; }
        [Required]
        [Display(Name = "WallPosition", ResourceType = typeof(Resources))]
        public WallPosition WallPosition { get; set; }
        [Required]
        [Display(Name = "CastlePosition", ResourceType = typeof(Resources))]
        public CastlePosition CastlePosition { get; set; }
        [Required]
        [Display(Name = "Floor", ResourceType = typeof(Resources))]
        public Floor CastleFloor { get; set; }
        [Display(Name = "CastleNo", ResourceType = typeof(Resources))]
        public int CastleNo { get; set; }
        /// <summary>
        /// Bağlantılar
        /// </summary>
        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
        public ICollection<CastleLdrPoint> CastleLdrPoint { get; set; }
        public ICollection<Target> Target { get; set; }
        /// <summary>
        /// Özellikler
        /// </summary>
        
        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string Name => $"Station : {(this.Station != null ? this.Station.Name:"")} - Wall Position : {this.WallPosition} - Position : {this.CastlePosition} - Floor : {this.CastleFloor}";

        public override string ToString()
        {
            return
                $"Station : {this.Station.Name} - Wall Position : {this.WallPosition} - Position : {this.CastlePosition} - Floor : {this.CastleFloor}";
        }
    }
}
