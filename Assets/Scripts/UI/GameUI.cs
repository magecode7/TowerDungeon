using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject restartMenu;

    private bool showRestart = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
        restartMenu.SetActive(false);

        EventManager.I.onPlayerDied += ShowRestartMenu;
    }

    public void Pause()
    {
        if (!showRestart)
        {
            Time.timeScale = 0;
            MusicManager.I.SetPitch(0.75f);
            pauseMenu.SetActive(true);
        }
    }
    
    public void Unpause()
    {
        Time.timeScale = 1;
        MusicManager.I.SetPitch(1);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Unpause();
        SceneManager.LoadSceneAsync("Game");
    }

    public void Exit()
    {
        Unpause();
        SceneManager.LoadSceneAsync("Menu");
    }

    public void ShowRestartMenu()
    {
        MusicManager.I.SetPitch(0.75f);
        restartMenu.SetActive(true);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (pauseMenu.activeSelf) Unpause();
            else Pause();
    }
}
