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

        private readonly float _speed = 1;
        private readonly float _moveRate = 0.05f;

        private bool _isTurning = false;
        private bool _isMoving = false;

        private Vector2 _moveDirection = Vector2.right;
        private Vector2 _previousDirection = Vector2.zero;

        private Vector3 _previousPosition = Vector3.zero;
        private Vector3 _destinationPosition = Vector3.zero;

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

        private void Update()
        {
            if (_isMoving)
            {
                var absDistance = _destinationPosition - transform.position;
                if (Mathf.Abs(absDistance.magnitude) <= _moveRate)
                {
                    _isMoving = false;
                    transform.position = _destinationPosition;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, _destinationPosition, _moveRate);
                }
            }
        }

        public void Translate()
        {
            _isMoving = true;
            _previousPosition = transform.position;
            var newPosition = transform.position;
            var speedVector = _moveDirection * _speed;
            newPosition.x += speedVector.x;
            newPosition.y += speedVector.y;
            _destinationPosition = newPosition;

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
            _destinationPosition = _previousPosition;
        }

        public void ResetPosition()
        {
            _isMoving = false;
            transform.position = _startingPosition;
        }
    }
}