using Game.Commands;
using System;

namespace Game.Observer.Listeners
{
    [Serializable]
    public class BaseCommandListener : GenericEventListener<BaseCommand>
    {
    }
}