using Game.Commands;
using Game.Commands.Factory;
using Game.Enums;
using Game.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CommandButton : MonoBehaviour
    {
        [SerializeField]
        private CommandType _commandType;

        [SerializeField]
        private BaseCommandEvent _event;

        private BaseCommand _command;

        private void Start()
        {
            var imageComponent = GetComponent<Image>();
            _command = BaseCommandFactory.CreateCommand(_commandType);
            _command.sprite = imageComponent.sprite;
        }

        public void AddCommand()
        {
            _event.OnOcurred(_command);
        }
    }
}