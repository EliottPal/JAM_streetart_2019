using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CharacController controller = other.GetComponent<CharacController>();

        if (controller != null)
        {
            controller.ChangeKey();
            gameObject.SetActive(false);
        }
    }
}
