using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
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

   
}
