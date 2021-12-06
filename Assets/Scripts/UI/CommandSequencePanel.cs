using Game.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class CommandSequencePanel : MonoBehaviour
    {
        private List<CommandSequenceButton> commandButtons;

        // Start is called before the first frame update
        private void Start()
        {
            commandButtons = new List<CommandSequenceButton>(GetComponentsInChildren<CommandSequenceButton>());
        }

        public void UpdateButton(BaseCommand command)
        {
        }
    }
}