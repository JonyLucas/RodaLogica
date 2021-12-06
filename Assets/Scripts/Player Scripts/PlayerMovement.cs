using Game.Extensions;
using UnityEngine;

namespace Game.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        // Fields
        [SerializeField]
        private Vector3 _startingPosition;

        [SerializeField]
        private float _xLimit;

        [SerializeField]
        private float _yLimit;

        private readonly float _speed = 1;

        private Vector2 _moveDirection = Vector2.right;

        protected Sprite _forwardSprite;
        protected Sprite _backwardSprite;
        protected Sprite _upwardSprite;
        protected Sprite _down;

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

        public void ResetPosition()
        {
            transform.position = _startingPosition;
        }
    }
}