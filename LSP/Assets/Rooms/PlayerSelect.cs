using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour {
    public List<Light> RoomLights;
    public Text text;
    public bool RoomEnabled = false;
	// Use this for initialization
	void Start () {
        text.text = "";
        for (int i = 0; i < RoomLights.Count; i++)
        {
            RoomLights[i].enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        else if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void OnTriggerEnter(Collider c)
    {
        text.text = c.tag[c.tag.Length-1].ToString();
        this.gameObject.tag = c.tag;
        for (int i = 0; i < RoomLights.Count; i++) {
            RoomLights[i].enabled = true;
            RoomEnabled = true;
        }
    }
    void OnTriggerExit(Collider c) {
        text.text = "";
        this.gameObject.tag = "Untagged";
        for (int i = 0; i < RoomLights.Count; i++)
        {
            RoomEnabled = false;
            RoomLights[i].enabled = false;
        }
    }
}
