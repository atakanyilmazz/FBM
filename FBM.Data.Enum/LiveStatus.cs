using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Enum
{
    public enum LiveStatus
    {
        [Display(Name = "Başlatılıyor")]
        Starting = 0,
        [Display(Name = "Top Atıldı")]
        BallThrown = 1,
        [Display(Name = "Gol Başarılı")]
        GoalSuccess = 2,
        [Display(Name = "Gol Başarısız")]
        GoalUnSuccess = 4,
        [Display(Name = "Top Atıldı")]
        HalfTime = 5,
        [Display(Name = "Program Bitti")]
        End = 6
    }
}
