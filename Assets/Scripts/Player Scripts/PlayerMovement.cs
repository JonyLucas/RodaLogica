using Game.Extensions;
using UnityEngine;

namespace Game.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        // Fields
        [SerializeField]
        protected Sprite _forwardSprite;

        [SerializeField]
        protected Sprite _backwardSprite;

        [SerializeField]
        protected Sprite _upwardSprite;

        [SerializeField]
        protected Sprite _down;

        private bool _failed = false;

        private float _speed = 1;

        private Vector2 _moveDirection = Vector2.right;

        protected new SpriteRenderer renderer;

        // Properties
        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value.GetProminentVectorComponent(); }
        }

        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        public void Move()
        {
            Translate();
            Rotate();
        }

        private void Translate()
        {
            var newPosition = transform.position;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            transform.position = newPosition;
        }

        // Change the player's sprites
        private void Rotate()
        {
        }

        public bool HasFailed()
        {
            return _failed;
        }
    }
}