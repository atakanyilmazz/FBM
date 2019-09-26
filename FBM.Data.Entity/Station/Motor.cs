using FBM.Core.Resource;
using FBM.Data.Entity.Throw;
using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Station
{
    public class Motor : BaseEntity
    {
        [Required]
        [Display(Name = "Station", ResourceType = typeof(Resources))]
        public Guid StationId { get; set; }
        [Required]
        [Display(Name = "StationNo", ResourceType = typeof(Resources))]
        public int StationNo { get; set; }
        [Required]
        [Display(Name = "Floor", ResourceType = typeof(Resources))]
        public Floor Floor { get; set; }
        [Required]
        [Display(Name = "WallPosition", ResourceType = typeof(Resources))]
        public WallPosition WallPosition { get; set; }


        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
        public ICollection<Throwing> Throwing { get; set; }
        public string Name => $"{((this.Station != null) ? this.Station.Name:"")}, {this.WallPosition} {this.Floor}";

        public override string ToString()
        {
            return $"{this.Station.Name}, {this.WallPosition} {this.Floor}";
        }
    }
}
