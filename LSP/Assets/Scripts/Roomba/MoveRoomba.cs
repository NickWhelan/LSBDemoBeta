using UnityEngine;
using System.Collections;

public class MoveRoomba : MonoBehaviour
{
    public bool Move = false;
    public bool Forward, Left, Right, Back,TwoBothInTriggers;
    public GameObject customOrigin;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (Forward)
            {
                transform.position += transform.forward;
            }
            if (Left)
            {
                if (!TwoBothInTriggers)
                {
                    transform.RotateAround(customOrigin.transform.position + new Vector3(1,0,0), new Vector3(0, 1, 0), -1);
                }
                else {
                    transform.RotateAround(customOrigin.transform.position, new Vector3(0, 1, 0), -1);
                }
            }
            if (Right)
            {
                if (!TwoBothInTriggers)
                {
                    transform.RotateAround(customOrigin.transform.position + new Vector3(-1, 0, 0), new Vector3(0, 1, 0), 1);
                }
                else
                {
                    transform.RotateAround(customOrigin.transform.position, new Vector3(0, 1, 0), 1);
                }
            }
            if (Back)
            {
                transform.position += transform.forward*-1;
            }
        }
    }
}
