using Game.ScriptableObjects.Events;
using UnityEngine;

public class ObjectiveContact : MonoBehaviour
{
    [SerializeField]
    private GameEvent _event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _event.OnOcurred();
        }
    }
}