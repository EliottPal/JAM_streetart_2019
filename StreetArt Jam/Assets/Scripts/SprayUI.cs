using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class SprayUI : MonoBehaviour
{
    public Sprite active;
    public Sprite inactive;
    public AudioSource spray;
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
                Debug.Log("Spray inactive");
            }
            else if (isActive == false) {
                isActive = true;
                this.GetComponent<SpriteRenderer>().sprite = active;
                spray.Play();
                Debug.Log("Spray Active");
            }
        }
    }
}