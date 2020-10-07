using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.UnityCore
{
    public class TaskDTO
    {
        public TaskType taskType { get; set; }
        public object jSonValue { get; set; }
    }

    public enum TaskType { 
        ThrowSingleBallToCastle =   0,
        ThrowSingleBall =           1
    }
}
