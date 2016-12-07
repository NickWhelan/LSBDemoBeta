using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool paused = false;

    [Range(1, 10), SerializeField]
    int minutes = 1;
    float seconds = 0;
    float milliseconds = 0;

    public Text timerText;

    [Header("Panels")]
    public GameObject loadingPanel;
    public GameObject scorePanel;

    [Header("Score Panel Info")]
    public Text scoreOneText;
    public Text scoreTwoText;
    private int teamOneScore;
    private int teamTwoScore;

    [Header("Loading Panel Info")]
    public Slider loadingSlider;
    public Text progressText;
    private int loadingProgress;

    // Use this for initialization
    void Start()
    {
        timerText.text = "00 : 00 : 00 ";
        scorePanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (milliseconds <= 0 && !paused)
            {
                if (seconds <= 0 && minutes <= 0)
                {
                    Debug.Log("Game should end here");
                    paused = true;
                    timerText.text = "";
                    LoadScorePanel();
                }
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else if (seconds >= 0)
                {
                    seconds--;
                }
                milliseconds = 100;
            }
            milliseconds -= Time.deltaTime * 100;
            timerText.text = string.Format("{0} : {1} : {2}", minutes, seconds, (int)milliseconds);
        }
    }

    /// <summary>
    /// Enable the score panel
    /// </summary>
    void LoadScorePanel()
    {
        scorePanel.SetActive(true);
        timerText.enabled = false;
        //Display score text
        scoreOneText.text = teamOneScore.ToString();
        scoreTwoText.text = teamTwoScore.ToString();
    }

    /// <summary>
    /// Update Score takes in an int that corresponds to the team that scored. 
    /// </summary>
    /// <param name="teamThatScored"> 0 is Team One, 1 is Team Two</param>
    public void UpdateScore(int teamThatScored)
    {
        switch (teamThatScored)
        {
            ///Team One Scored!
            case 0:
                teamOneScore++;
                break;

            ///Team Two Scored!
            case 1:
                teamTwoScore++;
                break;

            default:
                Debug.Log("Nothing Happened in the score updater");
                break;
        }
    }

    //Panel Convenience
    void LoadingPanelScreen()
    {
        loadingPanel.SetActive(true);
       // mainButtons.SetActive(false);
    }

    /// <summary>
    /// Load the prototype menu
    /// </summary>
    public void PrototypeMenu()
    {
        LoadingPanelScreen();
        StartCoroutine(LoadScreen("Main"));
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    //Loading screen coroutine
    /// <summary>
    /// Enable the loading screen to load to display loading progress
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
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


    //Paused Methods
    public bool GetPausedState()
    {
        return paused;
    }

    public void SetPausedState(bool pausedState)
    {
        paused = pausedState;
        //Load Paused Screen?
    }

}
