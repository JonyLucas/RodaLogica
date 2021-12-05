using Game.Extensions;
using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        // Fields
        //[SerializeField]
        //private PlayerMoveData _moveData;

        //[SerializeField]
        //protected PlayerSprites _sprites;

        private float _speed = 10;

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
            // Sets the player's movement data
            //_speed = _moveData.Speed;
            //_stopMove = _moveData.StopMove;
            //_xLimit = _moveData.XLimit;
            //_yLimit = _moveData.YLimit;

            //_canChangeDirection = true;

            renderer = GetComponent<SpriteRenderer>();

            SetSprites();
            SetNextBodyBlock();
        }

        protected abstract void SetSprites();

        public abstract void SetNextBodyBlock(GameObject nextBlock = null);

        protected virtual void Movement()
        {
            Translate();
            Rotate();
        }

        protected void Translate()
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
    }
}