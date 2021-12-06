using Game.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Props
{
    public class ObstacleCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var moveScript = collision.GetComponent<PlayerMovement>();
                moveScript.ReturnPosition();
            }
        }
    }
}