using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Sprites", menuName = "Player Sprites", order = 52)]
    public class PlayerSprites : ScriptableObject
    {
        // Snake's body Sprites

        public Sprite turnBodyFirstQuadrantSprite;
        public Sprite turnBodySecondQuadrantSprite;
        public Sprite turnBodyThirdQuadrantSprite;
        public Sprite turnBodyFourthQuadrantSprite;
        public Sprite bodyVerticalSprite;
        public Sprite bodyHorizontalSprite;
    }
}