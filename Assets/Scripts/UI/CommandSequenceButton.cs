using Game.Commands;
using Game.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CommandSequenceButton : MonoBehaviour
    {
        [SerializeField]
        private int _index;

        [SerializeField]
        private IntGameEvent _event;

        [SerializeField]
        private Sprite _emptySpace;

        private Image _imageComponent;

        private Transform _nextCommandButton;

        private bool _hasCommand = false;

        public bool HasCommand
        { get { return _hasCommand; } }

        private void Start()
        {
            _imageComponent = GetComponent<Image>();
            _nextCommandButton = transform.parent.transform.GetChild(_index + 1);
        }

        public void AddCommand(BaseCommand command)
        {
            _hasCommand = true;
            _imageComponent.sprite = command.sprite;
        }

        public void RemoveCommand()
        {
            UpdateNextButton();
            _event.OnOcurred(_index);
        }

        public void UpdateNextButton()
        {
            if (_nextCommandButton != null)
            {
                var buttonScript = _nextCommandButton.GetComponent<CommandSequenceButton>();
                _imageComponent.sprite = buttonScript.GetSprite();
                buttonScript.UpdateNextButton();
            }
            else
            {
                _hasCommand = false;
                _imageComponent.sprite = _emptySpace;
            }
        }

        public Sprite GetSprite()
        {
            return _imageComponent.sprite;
        }
    }
}