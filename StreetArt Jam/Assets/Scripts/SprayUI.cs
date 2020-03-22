using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class SprayUI : MonoBehaviour
{
    public Sprite active;
    public Sprite inactive;
    public AudioSource open;
    public AudioSource close;
    bool isActive;

    void Start()
    {
        isActive = false;
        this.GetComponent<SpriteRenderer>().sprite = inactive;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) {
            if (isActive == true) {
                isActive = false;
                this.GetComponent<SpriteRenderer>().sprite = inactive;
                close.Play();
                Debug.Log("Spray inactive");
            }
            else if (isActive == false) {
                isActive = true;
                this.GetComponent<SpriteRenderer>().sprite = active;
                open.Play();
                Debug.Log("Spray Active");
            }
        }
    }
}