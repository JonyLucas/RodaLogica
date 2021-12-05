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
                moveScript.Move();
            }
        }

        protected bool ExecutionCodition(PlayerMovement moveScript)
        {
            if (moveScript != null)
            {
                //var moveScript = gameObject.GetComponent<HeadMovement>();
                //var snakeMoveDirection = moveScript.MoveDirection;
                //var isValidDirection = snakeMoveDirection != MoveDirection && snakeMoveDirection != MoveDirection * (-1);
                //return isValidDirection && moveScript.CanChangeDirection;
                return true;
            }

            return false;
        }
    }
}