using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
