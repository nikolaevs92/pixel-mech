using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameManager gameManager;
    void Start() {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    public void ReturnToGame() {
        gameManager.UnPause();
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
