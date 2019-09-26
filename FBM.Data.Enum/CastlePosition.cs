using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Enum
{
    public enum CastlePosition
    {
        [Display(Name = "Castle1", ResourceType = typeof(Resources))]
        Castle1 = 0,    //Kale Soldan 1 
        [Display(Name = "Castle2", ResourceType = typeof(Resources))]
        Castle2,        //Kale Soldan 2
        [Display(Name = "Castle3", ResourceType = typeof(Resources))]
        Castle3,        //Kale Soldan 3
        [Display(Name = "Castle4", ResourceType = typeof(Resources))]
        Castle4,        //Kale Soldan 4
        [Display(Name = "Castle5", ResourceType = typeof(Resources))]
        Castle5,        //Kale Soldan 5
        [Display(Name = "Castle6", ResourceType = typeof(Resources))]
        Castle6,        //Kale Soldan 6
        [Display(Name = "Castle7", ResourceType = typeof(Resources))]
        Castle7,        //Kale Soldan 7
        [Display(Name = "Castle8", ResourceType = typeof(Resources))]
        Castle8,        //Kale Soldan 8
        [Display(Name = "Castle9", ResourceType = typeof(Resources))]
        Castle9,        //Kale Soldan 9
    }
}
