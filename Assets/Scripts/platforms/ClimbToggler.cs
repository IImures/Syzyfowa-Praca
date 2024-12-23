using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ClimbToggler : MonoBehaviour
{
    private void Toggle(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().ToggleVerticalMovement();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Toggle(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Toggle(other);
    }
}
