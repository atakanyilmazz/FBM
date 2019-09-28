using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Station
{
    public class Station : NamedEntity
    {
        [NotMapped]
        public bool HasBall { get; set; } = false;
        [NotMapped]
        public int? BallCount { get; set; } = null;
        /// <summary>
        /// Bağlantılar
        /// </summary>
        public ICollection<Castle> Castle { get; set; }
        public ICollection<Motor> Motor { get; set; }
        public ICollection<Ldr> Ldr { get; set; }
        public ICollection<DeviceInfo> DeviceInfo { get; set; }
    }
}
