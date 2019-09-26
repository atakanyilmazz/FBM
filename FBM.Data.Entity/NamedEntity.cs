using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity
{
    public class NamedEntity : BaseEntity
    {
        [Required]
        [Display(Name = "labelForName", ResourceType = typeof(Resources))]
        public string Name { get; set; }



        [Display(Name = "labelForDesctription", ResourceType = typeof(Resources))]
        public string Desctription { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
