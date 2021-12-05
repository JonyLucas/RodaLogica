using System;
using UnityEngine;

namespace Game.Commands
{
    [Serializable]
    public abstract class BaseCommand
    {
        /// <summary>
        /// Execute an action implemented by the command pattern.
        /// </summary>
        /// <param name="gameObject"></param>
        public abstract void Execute(GameObject gameObject);
    }
}