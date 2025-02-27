using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    //[SerializeField] private 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (nextLevelName != null)
            {
                SceneManager.LoadSceneAsync("nextLevelName");
            }
        }
    }
}
