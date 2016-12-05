using UnityEngine;
using System.Collections;

public class Curve : MonoBehaviour {
    public Camera cam;
    Vector3 OrginPoint; 
    public GameObject EndPoint;
    public GameObject OrginPointControl, EndPointControl;
    Vector3 ScreenZeroZero;
    LineRenderer line;
    public int numberOfsegInLine = 100;
    public Transform OrginPointControlObj, EndPointControlObj;
    // Update is called once per frame
    public void Start() {
        line = GetComponent<LineRenderer>();

        ScreenZeroZero = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Random.Range(30,40)));
        OrginPoint = ScreenZeroZero;
        //EndPoint.transform.position = cam.ScreenToWorldPoint(new Vector3(0, 0, 38.5f));
        //OrginPointControlObj.transform.position = OrginPoint;
        OrginPointControlObj.transform.position = new Vector3(OrginPoint.x, OrginPoint.y-10, OrginPoint.z-5f);
        EndPointControlObj.transform.position = new Vector3(EndPoint.transform.position.x, EndPoint.transform.position.y-10, EndPoint.transform.position.z+15);

        //line.SetVertexCount(numberOfsegInLine);
        line.numPositions = numberOfsegInLine;
    }
    void Update()
    {
        //OrginPointControl = OrginPointControlObj.position;
       // EndPointControl = EndPointControlObj.position;
        for (int i = 0; i < numberOfsegInLine; ++i)
        {
            float t = (float)i / (float)(numberOfsegInLine - 1);
            // Bezier curve function
            Vector3 pos = Mathf.Pow((1 - t), 3) * OrginPoint + 3 * Mathf.Pow((1 - t), 2) * t * OrginPointControl.transform.position + 3 * (1 - t) * Mathf.Pow(t, 2) * EndPointControl.transform.position + Mathf.Pow(t, 3) * EndPoint.transform.position;
            line.SetPosition(i, pos);
        }

    }
}
