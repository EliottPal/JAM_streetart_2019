using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Button yourButton;
    public AudioSource audioSource;
    bool isPlaying = true;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (isPlaying == true) {
            isPlaying = false;
            audioSource.Stop();
        } else {
            isPlaying = true;
            audioSource.Play();
        }
    }
}
