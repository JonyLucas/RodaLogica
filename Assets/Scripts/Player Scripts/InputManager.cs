using Game.Commands;
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

        private GameObject _player;

        private List<BaseCommand> _commands = new List<BaseCommand>();
        private List<Sprite> _commandSprite = new List<Sprite>();

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void AddCommand(BaseCommand command)
        {
            _commands.Add(command);
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