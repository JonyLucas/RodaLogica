using Game.Commands;
using Game.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CommandSequenceButton : MonoBehaviour
    {
        private int _index;

        [SerializeField]
        private IntGameEvent _event;

        [SerializeField]
        private Sprite _emptySpace;

        private Image _imageComponent;

        private bool _hasCommand = false;

        private bool _isRunning = false;

        private CommandSequenceButton _nextCommandButtonScript;

        public bool HasCommand
        { get { return _hasCommand; } }

        public Sprite SpriteImage
        { get { return _imageComponent.sprite; } }

        private void Start()
        {
            _imageComponent = GetComponent<Image>();
            _index = transform.GetSiblingIndex();

            if (_index < transform.parent.childCount - 1)
            {
                var nextCommandButton = transform.parent.transform.GetChild(_index + 1);
                _nextCommandButtonScript = nextCommandButton.GetComponent<CommandSequenceButton>();
            }
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
            if (_nextCommandButtonScript != null)
            {
                _imageComponent.sprite = _nextCommandButtonScript.SpriteImage;
                _hasCommand = _nextCommandButtonScript.HasCommand;
                _nextCommandButtonScript.UpdateNextButton();
            }
            else
            {
                _hasCommand = false;
                _imageComponent.sprite = _emptySpace;
            }
        }

        public void SwitchRunningState()
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                _imageComponent.color = new Color(157, 157, 157);
            }
            else
            {
                _imageComponent.color = Color.white;
                if (_nextCommandButtonScript == null || !_nextCommandButtonScript.HasCommand)
                {
                    var gameObj = GameObject.Find("BlockPanel");
                    gameObj.SetActive(false);
                }
            }
        }
    }
}