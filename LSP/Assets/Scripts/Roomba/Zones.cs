using UnityEngine;
using System.Collections;

public class Zones : MonoBehaviour {
    MoveRoomba Roomba;
	// Use this for initialization
	void Start () {
        Roomba = GetComponentInParent<MoveRoomba>();
	}
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.tag);
        if (other.tag.StartsWith("Player"))
        {
            Roomba.Move = true;
            if (gameObject.tag == "Left")
            {
                Roomba.Left = true;
            }
            if (gameObject.tag == "Right")
            {
                Roomba.Right = true;
            }
            if (gameObject.tag == "Up")
            {
                Roomba.Forward = true;
            }
            if (gameObject.tag == "Down")
            {
                Roomba.Back = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag.StartsWith("Player"))
        {
            Roomba.Move = false;
            if (gameObject.tag == "Left")
            {
                Roomba.Left = false;
            }
            if (gameObject.tag == "Right")
            {
                Roomba.Right = false;
            }
            if (gameObject.tag == "Up")
            {
                Roomba.Forward = false;
            }
            if (gameObject.tag == "Down")
            {
                Roomba.Back = false;
            }
        }
    }
}
