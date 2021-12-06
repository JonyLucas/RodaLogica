using Game.Extensions;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        // Fields
        [SerializeField]
        private PlayerSprites _sprites;

        [SerializeField]
        private Vector3 _startingPosition;

        [SerializeField]
        private float _xLimit;

        [SerializeField]
        private float _yLimit;

        private readonly float _speed = 1;

        private bool _isTurning = false;

        private Vector2 _moveDirection = Vector2.right;
        private Vector2 _previousDirection = Vector2.zero;

        private Vector3 _previousPosition = Vector3.zero;

        protected Sprite _forwardSprite;
        protected Sprite _backwardSprite;
        protected Sprite _upwardSprite;
        protected Sprite _down;

        private SpriteRenderer _renderer;

        // Properties
        public Vector2 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value.GetProminentVectorComponent(); }
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            transform.position = _startingPosition;
        }

        public void Translate()
        {
            _previousPosition = transform.position;
            var newPosition = transform.position;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            transform.position = newPosition;

            if (_isTurning)
            {
                _isTurning = false;
                UpdateSprite();
            }
        }

        private void UpdateSprite()
        {
            var normalizedVector = _moveDirection.GetProminentVectorComponent();
            if (normalizedVector == Vector2.up)
            {
                _renderer.sprite = _sprites.playerMoveUp;
            }
            else if (normalizedVector == Vector2.right)
            {
                _renderer.sprite = _sprites.playerMoveRight;
            }
            else if (normalizedVector == Vector2.down)
            {
                _renderer.sprite = _sprites.playerMoveDown;
            }
            else
            {
                _renderer.sprite = _sprites.playerMoveLeft;
            }
        }

        public void Rotate(bool isClockwise)
        {
            _isTurning = true;
            _previousDirection = _moveDirection.GetProminentVectorComponent();
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
                _renderer.sprite = _previousDirection == Vector2.right ? _sprites.playerTurnUpRight : _sprites.playerTurnLeftUp;
            }
            else if (normalizedVector == Vector2.right)
            {
                _renderer.sprite = _previousDirection == Vector2.up ? _sprites.playerTurnUpRight : _sprites.playerTurnRightDown;
            }
            else if (normalizedVector == Vector2.down)
            {
                _renderer.sprite = _previousDirection == Vector2.right ? _sprites.playerTurnRightDown : _sprites.playerTurnDownLeft;
            }
            else
            {
                _renderer.sprite = _previousDirection == Vector2.down ? _sprites.playerTurnDownLeft : _sprites.playerTurnLeftUp;
            }
        }

        public void ReturnPosition()
        {
            transform.position = _previousPosition;
        }

        public void ResetPosition()
        {
            transform.position = _startingPosition;
        }
    }
}