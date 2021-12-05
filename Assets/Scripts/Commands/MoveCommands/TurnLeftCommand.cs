using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnLeftCommand : BaseCommand
    {
        public Vector2 MoveDirection
        { get { return Vector2.left; } }

        public override void Execute(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}