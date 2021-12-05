using Game.Player.Movement;
using System;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class TurnAntiClockwiseCommand : BaseCommand
    {
        public override void Execute(GameObject gameObject)
        {
            var moveScript = gameObject.GetComponent<PlayerMovement>();
            if (ExecutionCodition(moveScript))
            {
                moveScript.Rotate(isClockwise: false);
            }
        }

        private bool ExecutionCodition(PlayerMovement moveScript)
        {
            if (moveScript != null)
            {
                return !moveScript.HasFailed();
            }

            return false;
        }
    }
}