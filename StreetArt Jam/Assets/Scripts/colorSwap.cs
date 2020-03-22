using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSwap : MonoBehaviour
{
    public Sprite blue;
    public Sprite green;

    bool isActive;

    void Start()
    {
        isActive = false;
        this.GetComponent<SpriteRenderer>().sprite = blue;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B)) {
            if (isActive == true) {
                isActive = false;
                this.GetComponent<SpriteRenderer>().sprite = blue;
                Debug.Log("Blue spray");
            }
            else if (isActive == false) {
                isActive = true;
                this.GetComponent<SpriteRenderer>().sprite = green;
                Debug.Log("Green spray");
            }
        }
    }
}
