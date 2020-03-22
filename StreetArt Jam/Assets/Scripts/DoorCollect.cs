using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CharacController controller = other.GetComponent<CharacController>();

        if (controller != null)
        {
            controller.ChangeEnd();
        }
    }
}
