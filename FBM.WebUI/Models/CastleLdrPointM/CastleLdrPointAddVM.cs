using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Models.CastleLdrPointM
{
    public class CastleLdrPointAddVM
    {
        [Required]
        [Display(Name = "Castle", ResourceType = typeof(Resources))]
        public Guid CastleId { get; set; }

        [Required]
        [Display(Name = "StartPoint", ResourceType = typeof(Resources))]
        public int XStartPoint { get; set; }
        [Required]
        [Display(Name = "EndPoint", ResourceType = typeof(Resources))]
        public int XEndPoint { get; set; }


        [Required]
        [Display(Name = "StartPoint", ResourceType = typeof(Resources))]
        public int YStartPoint { get; set; }
        [Required]
        [Display(Name = "EndPoint", ResourceType = typeof(Resources))]
        public int YEndPoint { get; set; }
    }
}