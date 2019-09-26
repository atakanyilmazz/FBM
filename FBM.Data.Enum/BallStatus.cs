using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Enum
{
    public enum BallStatus
    {
        Out = 0,        //Top atılmadı
        Thrown = 1,     //Top Fırlatılmış 
        Success,        //Başarılı Gol
        Unsuccessful,   //Başarısız
        Passed,         //Top Geçti
        HalfTime        //Yarı Zaman Geçti
    }
}
