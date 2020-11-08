﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static LevelLoader instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    } 

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    } 

    IEnumerator LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
    }


}