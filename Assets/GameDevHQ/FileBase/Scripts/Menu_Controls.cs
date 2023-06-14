using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controls : MonoBehaviour
{

    private async void ReloadSceneAsync()
    {
        var asyncOperation = SceneManager.LoadSceneAsync("GLI_1", LoadSceneMode.Single);
        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }
    }

    private async void LoadMainMenuAsync()
    {
        var asyncOperation = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("GLI_1");
    }

    public void RestartGame()
    {
        ReloadScene();
    }

    public void MainMenu()
    {
        LoadMainMenuAsync();
    }
}
