using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    float seconds = 0;

    [Range(1, 10), SerializeField]
    int minutes = 1;
    float milliseconds = 0;

    Text timerText;

	// Use this for initialization
	void Start () {
        timerText = GetComponentInChildren<Text>();
        timerText.text = "00 : 00 : 00 ";
	}
	
	// Update is called once per frame
	void Update () {
        if (milliseconds <= 0)
        {
            if (seconds <= 0 && minutes <= 0)
            {
                Debug.Log("Game should end here");
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
