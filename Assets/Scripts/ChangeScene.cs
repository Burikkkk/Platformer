using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    // Метод для выхода из игры
    public void ExitGame()
    {

        // Если игра запущена в редакторе, то остановить игру
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если игра запущена как сборка, то закрыть приложение
        Application.Quit();
#endif
    }

    public static void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
