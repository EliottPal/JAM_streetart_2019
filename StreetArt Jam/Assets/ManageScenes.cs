using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScenes : MonoBehaviour
{
    public void ToggleFullScreen(bool isFullScreen) {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("FULLSCREEN MODE: " + Screen.fullScreen);
    }
}
