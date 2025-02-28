using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private bool hasNextLevel;

    [SerializeField] private GameObject endPanel;
    [SerializeField] private AudioSource levelSource;
    [SerializeField] private AudioClip winClip;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hasNextLevel == true)
            {
                ChangeScene.LoadNextLevel();
            }
            else
            {
                animator.SetBool("IsOpened", true);

            }
        }
    }

    private void EndLevel()
    {
        endPanel.SetActive(true);
        levelSource.PlayOneShot(winClip);
        Time.timeScale = 0.0f;
    }
}
