using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _yLimit;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (transform.position.y < _yLimit)
        {
            var newPosition = transform.position;
            newPosition.y = -newPosition.y;
            transform.position = newPosition;
        }
    }
}