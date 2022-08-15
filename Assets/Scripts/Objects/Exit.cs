using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public delegate void ExitEvents();
    public static ExitEvents OnLevelComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out _))
        {
            OnLevelComplete.Invoke();
        }
    }
}
