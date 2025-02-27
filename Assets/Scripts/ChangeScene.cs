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

    // ����� ��� ������ �� ����
    public void ExitGame()
    {

        // ���� ���� �������� � ���������, �� ���������� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ���� ���� �������� ��� ������, �� ������� ����������
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
