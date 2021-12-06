using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Sprites", menuName = "Player Sprites", order = 52)]
    public class PlayerSprites : ScriptableObject
    {
        // Snake's body Sprites

        public Sprite playerMoveLeft;
        public Sprite playerMoveRight;
        public Sprite playerMoveUp;
        public Sprite playerMoveDown;
        public Sprite playerTurnRightDown;
        public Sprite playerTurnDownLeft;
        public Sprite playerTurnLeftUp;
        public Sprite playerTurnUpRight;
    }
}