using UnityEngine;

using System.Collections;

public class MoveCable : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if ((this.tag == "Player1" && Input.GetKey("a")) || (this.tag == "Player2" && Input.GetKey("left")))
        {
            this.transform.position -= new Vector3(0, 0, 0.2f);
        }
        else if ((this.tag == "Player1" && Input.GetKey("d")) || (this.tag == "Player2" && Input.GetKey("right")))
        {
            this.transform.position += new Vector3(0, 0, 0.2f);
        }
        if ((this.tag == "Player1" && Input.GetKey("w")) || (this.tag == "Player2" && Input.GetKey("up")))
        {
            this.transform.position += new Vector3(0, 0.2f, 0);
        }
        else if ((this.tag == "Player1" && Input.GetKey("s")) || (this.tag == "Player2" && Input.GetKey("down")))
        {
            this.transform.position -= new Vector3(0, 0.2f, 0);
        }


    }
}