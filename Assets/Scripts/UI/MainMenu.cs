using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LoadBar loadBar;

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadScene()
    {
        loadBar.Show();

        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        while (!operation.isDone)
        {
            loadBar.UpdateVisual(operation.progress);

            yield return null;
        }

        loadBar.Hide();
    }
}
