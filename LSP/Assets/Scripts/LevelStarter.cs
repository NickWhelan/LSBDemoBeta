using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelStarter : MonoBehaviour {
    public GameObject loadingPanel;
    
    public Slider loadingSlider;
    public Text progressText;
    private int loadingProgress;

	// Use this for initialization
	void Start () {
        loadingPanel.SetActive(false);

	}

    private void Update()
    {
        ///Check for collision between two rooms
        ///if true, load roomba
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        
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
    }


    //Loading screen coroutine
    IEnumerator LoadScreen(string s)
    {
        AsyncOperation aSync = SceneManager.LoadSceneAsync(s);

        while (!aSync.isDone)
        {
            loadingSlider.value = loadingProgress;
            progressText.text = loadingProgress + "%";
            loadingProgress = (int)(aSync.progress + 100);

            yield return null;
        }
    }
}
