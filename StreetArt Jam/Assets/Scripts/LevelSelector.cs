using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelOne() {
        SceneManager.LoadScene("Level1");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
}
