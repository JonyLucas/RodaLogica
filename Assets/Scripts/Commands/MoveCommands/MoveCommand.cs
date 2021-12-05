using Game.Player.Movement;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Commands.MoveCommands
{
    [Serializable]
    public class MoveCommand : BaseCommand
    {
        public override void Execute(GameObject gameObject)
        {
            var moveScript = gameObject.GetComponent<PlayerMovement>();
            if (ExecutionCodition(moveScript))
            {
                moveScript.Translate();
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