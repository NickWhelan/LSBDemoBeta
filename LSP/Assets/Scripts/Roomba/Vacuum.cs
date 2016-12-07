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
                gm.UpdateScore(0);
                Destroy(c.gameObject);
            }
            if (gameObject.tag == "SecondRoomba")
            {
                gm.UpdateScore(1);
                Destroy(c.gameObject);
            }

        }

    }
}