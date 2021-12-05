using System;

namespace Game.Enums
{
    [Serializable]
    public enum CommandType
    {
        MoveCommand = 0,
        TurnRightCommand = 1,
        TurnLeftCommand = 2
    }
}