using Game.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var buttonCommand = commandButtons.FirstOrDefault(x => !x.HasCommand);
            if (buttonCommand != null)
            {
                buttonCommand.AddCommand(command);
            }
        }

        public void RemoveCommandFromButton(GameObject buttonObject)
        {
            var buttonScrip = buttonObject.GetComponent<CommandSequenceButton>();
            buttonScrip.RemoveCommand();
        }
    }
}