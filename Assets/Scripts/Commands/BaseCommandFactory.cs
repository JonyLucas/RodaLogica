using Game.Commands.MoveCommands;
using Game.Enums;

namespace Game.Commands.Factory
{
    public static class BaseCommandFactory
    {
        public static BaseCommand CreateCommand(CommandType commandType)
        {
            if (commandType == CommandType.MoveCommand)
            {
                return new MoveCommand();
            }
            else if (commandType == CommandType.TurnAntiClockwiseCommand)
            {
                return new TurnAntiClockwiseCommand();
            }
            else
            {
                return new TurnClockwiseCommand();
            }
        }
    }
}