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

        [SerializeField]
        private Vector3 _startingPosition;

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
            transform.position = _startingPosition;
        }

        public void Translate()
        {
            var newPosition = transform.position;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            transform.position = newPosition;
        }

        public void Rotate(bool isClockwise)
        {
            if (isClockwise)
            {
                _moveDirection = _moveDirection.RotateClockwise();
            }
            else
            {
                _moveDirection = _moveDirection.RotateAntiClockwise();
            }

            var normalizedVector = _moveDirection.GetProminentVectorComponent();
            // Change sprites
            if (normalizedVector == Vector2.up)
            {
            }
            else if (normalizedVector == Vector2.right)
            {
            }
            else if (normalizedVector == Vector2.down)
            {
            }
            else
            {
            }
        }

        public bool HasFailed()
        {
            return _failed;
        }
    }
}