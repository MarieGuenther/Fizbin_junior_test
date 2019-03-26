using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded = true;

    public bool IsGrounded() //returns if the character is standing the ground or not
    {
        return isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (!_collider.gameObject.CompareTag("Character"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _collider)
    {
        if (!_collider.gameObject.CompareTag("Character"))
        {
            isGrounded = false;
        }
    }
}
