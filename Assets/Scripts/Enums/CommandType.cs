using System;

namespace Game.Enums
{
    [Serializable]
    public enum CommandType
    {
        MoveCommand = 0,
        TurnClockwiseCommand = 1,
        TurnAntiClockwiseCommand = 2
    }
}