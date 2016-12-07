using UnityEngine;

using System.Collections;

public class MoveCable : MonoBehaviour
{
    public int PlayerNum;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, Input.GetAxis("Vertical" + PlayerNum)*0.5f, Input.GetAxis("Horizontal" + PlayerNum) * 0.5f);
     


    }
}