using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.transform.CompareTag("Character"))
        {
            _collider.transform.position = spawnPoint.position;
        }
    }

}
