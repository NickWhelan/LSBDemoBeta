using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
    public int playerId;
    // Variables to control speeds for movements
    public float speed = 6.0f;
   
    // Used by Move() to move the player in a certain direction
    Vector3 moveDirection = Vector3.zero;

    // Reference to controller used to move the player
    public CharacterController cc;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        // Grab a component and keep a reference to it
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotateSpeedX = Input.GetAxis("Mouse X");

        // Use the up and down keys to move the player along the Z-axis
        moveDirection = new Vector3(Input.GetAxis("Horizontal"+ playerId), 0, Input.GetAxis("Vertical"+ playerId));
        // Rotate the transform the Script is awttached to using to left and right keys
        transform.Rotate(0, rotateSpeedX * 3, 0);
        // Translates the local coordinates to world coordinates
        moveDirection = transform.TransformDirection(moveDirection);
        // Make the speed more than 1
        moveDirection *= speed;
        // Applies the Move action using the direction which had speed applied
        cc.Move(moveDirection * Time.deltaTime);

    } // closes Update

    void OnTriggerEnter(Collider c)
    {

    }
}
