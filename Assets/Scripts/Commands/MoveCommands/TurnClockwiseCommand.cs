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
            if (ExecutionCodition(moveScript))
            {
                moveScript.Rotate(isClockwise: true);
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