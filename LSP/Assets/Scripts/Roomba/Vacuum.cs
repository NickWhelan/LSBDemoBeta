using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public GameManager gm;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Dirt")
        {
            if (gameObject.tag == "FirstRoomba")
            {
                Debug.Log("ZHU LI DO THE THING");
                gm.UpdateScore(0);
                Destroy(c.gameObject);
            }
            if (gameObject.tag == "SecondRoomba")
            {
                Debug.Log("ZHU LI DO THE OTHER THING");
                gm.UpdateScore(1);
                Destroy(c.gameObject);
            }

        }

    }
}