using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaBotControlLib
{
    public enum AlphaBotControlCommand
    {
        Halt,

        MoveForward = 0,

        MoveBackward,

        TurnLeft,

        TurnRight,

        SpeedUp,

        SpeedDown,

        Flash,

        Undefined
    }
}
