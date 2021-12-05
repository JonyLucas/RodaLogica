using Game.Commands;
using Game.Commands.MoveCommands;
using Game.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private float _excuteRate = 1;

        [SerializeField]
        private int _maxCountCommads = 24;

        [SerializeField]
        private Sprite _moveButtonSprite;

        [SerializeField]
        private Sprite _turnRightButtonSprite;

        [SerializeField]
        private Sprite _turnLeftButtonSprite;

        private GameObject _player;

        private List<BaseCommand> _commands = new List<BaseCommand>();
        private List<Sprite> _commandSprite = new List<Sprite>();

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void AddCommand(int commandType)
        {
            Debug.Log("Add Command " + commandType);
            if (commandType == (int)CommandType.MoveCommand)
            {
                _commands.Add(new MoveCommand());
                _commandSprite.Add(_moveButtonSprite);
            }
            else if (commandType == (int)CommandType.TurnAntiClockwiseCommand)
            {
                _commands.Add(new TurnAntiClockwiseCommand());
                _commandSprite.Add(_turnLeftButtonSprite);
            }
            else
            {
                _commands.Add(new TurnClockwiseCommand());
                _commandSprite.Add(_turnRightButtonSprite);
            }
        }

        public void RunCommands()
        {
            StartCoroutine(RunCommandCoroutine());
        }

        private IEnumerator RunCommandCoroutine()
        {
            foreach (var command in _commands)
            {
                Debug.Log("Run Command: " + command.GetType().Name);
                yield return new WaitForSeconds(_excuteRate);
                command.Execute(_player);
            }
        }

        private Sprite GetSprite(int index)
        {
            return _commandSprite[index];
        }
    }
}