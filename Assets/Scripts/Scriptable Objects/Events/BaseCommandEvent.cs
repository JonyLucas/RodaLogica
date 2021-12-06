using Game.Commands;
using System;
using UnityEngine;

namespace Game.ScriptableObjects.Events
{
    [Serializable]
    [CreateAssetMenu(fileName = "Base Command Event", menuName = "Base Command Event", order = 56)]
    public class BaseCommandEvent : GenericGameEvent<BaseCommand>
    {
    }
}