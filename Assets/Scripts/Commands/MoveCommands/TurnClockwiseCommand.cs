using Game.Player.Movement;
using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnClockwiseCommand : BaseCommand
    {
        public override void Execute(GameObject gameObject)
        {
            var moveScript = gameObject.GetComponent<PlayerMovement>();
            if (moveScript != null)
            {
                moveScript.Rotate(isClockwise: false);
            }
        }
    }
}