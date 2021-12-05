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
        private float _excuteRate = 1;

        private GameObject _player;

        private List<BaseCommand> _commands = new List<BaseCommand>();

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
            }
            else if (commandType == (int)CommandType.TurnLeftCommand)
            {
                _commands.Add(new TurnLeftCommand());
            }
            else
            {
                _commands.Add(new TurnRightCommand());
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
    }
}