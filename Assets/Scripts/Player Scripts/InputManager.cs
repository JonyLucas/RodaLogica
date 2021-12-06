using Game.Commands;
using Game.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private IntGameEvent _commandExceuteEvent;

        [SerializeField]
        private GameEvent _gameOverEvent;

        private float _excuteRate = 1f;

        private int _maxCountCommands = 24;

        private bool _victoryCondition = false;

        private GameObject _player;

        private readonly List<BaseCommand> _commands = new List<BaseCommand>();

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            var commandSequence = GameObject.FindGameObjectWithTag("CommandSequence");
            if (commandSequence != null)
            {
                _maxCountCommands = commandSequence.transform.childCount;
            }
        }

        public void AddCommand(BaseCommand command)
        {
            if (_commands.Count <= _maxCountCommands)
            {
                _commands.Add(command);
            }
        }

        public void RemoveCommand(int index)
        {
            _commands.RemoveAt(index);
        }

        public void RunCommands()
        {
            StartCoroutine(RunCommandCoroutine());
        }

        private IEnumerator RunCommandCoroutine()
        {
            var size = _commands.Count;
            for (int index = 0; index < size; index++)
            {
                _commandExceuteEvent.OnOcurred(index);
                _commands[index].Execute(_player);

                yield return new WaitForSeconds(_excuteRate);
                _commandExceuteEvent.OnOcurred(index);

                if (_victoryCondition)
                {
                    break;
                }
            }

            if (!_victoryCondition)
            {
                _gameOverEvent.OnOcurred();
            }
        }

        public void SetVictoryCondition()
        {
            _victoryCondition = true;
        }
    }
}