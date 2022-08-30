using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isGameActive;
    // Update is called once per frame
    void Start() {
        UnPause();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGameActive) {
                Pause();
            } else {
                UnPause();
            }
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isGameActive = false;
    }
    public void UnPause() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGameActive = true;
    }
}
