﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

    public GameObject loadingPanel;
    public GameObject mainButtons;

    public Slider loadingSlider;
    public Text loadText;
    private int loadingProgress;

	// Use this for initialization
	void Start () {
        loadingPanel.SetActive(false);
	}

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    public void StartGame()
    {
        LoadPanelScreen();
        StartCoroutine(LoadScreen("Roomba"));
    }

    //Panel Convenience
    void LoadPanelScreen()
    {
        loadingPanel.SetActive(true);
        mainButtons.SetActive(false);
    }


    //Loading screen coroutine
    IEnumerator LoadScreen(string s)
    {
        AsyncOperation aSync = SceneManager.LoadSceneAsync(s);

        while(!aSync.isDone)
        {
            loadingSlider.value = loadingProgress;
            loadText.text = loadingProgress + "%";
            loadingProgress = (int)(aSync.progress + 100);

            yield return null;
        }
    }


}