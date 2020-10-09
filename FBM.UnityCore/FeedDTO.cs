using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.UnityCore
{
    public class FeedDTO
    {
        public List<FeedCastleDTO> feedCastles { get; set; }
        public List<FeedMotorDTO> feedMotors { get; set; }
    }



    public class FeedCastleDTO
    {
        public Guid id { get; set; }
        public int CastleNo { get; set; }
    }

    public class FeedMotorDTO
    {
        public Guid id { get; set; }
        public int MotorNo { get; set; }
        public List<FeedThrownDTO> feedThrowns { get; set; }
    }

    public class FeedThrownDTO 
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }

}
