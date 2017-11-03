using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[AddComponentMenu("Character Set Up/Character Movement")]

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

    #region Variables
    [Header("Characters MoveDirection")]
    Vector3 moveDir = Vector3.zero;
    private CharacterController charC;

    [Header("Character Variables")]
    public float jumpSpeed = 8f;
    public float speed = 6f;
    public float gravity = 20f;
    #endregion
    #region Start
    void Start()
    {
        charC = this.GetComponent<CharacterController>();
    }
    //charc is on this game object we need to get the character controller that is attached to it
    #endregion
    #region Update
    void Update()
    {


        //if our character is grounded
        if (charC.isGrounded)
        {
            //we are able to move in game scene meaning
            //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
            //Input(https://docs.unity3d.com/ScriptReference/Input.html)
            //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDir is transformed in the direction of our moveDir
            moveDir = transform.TransformDirection(moveDir);
            //our moveDir is then multiplied by our speed
            moveDir *= speed;
            //we can also jump if we are grounded so
            //in the input button for jump is pressed then
            if (Input.GetButton("Jump"))
            {
                //our moveDir.y is equal to our jump speed
                moveDir.y = jumpSpeed;
            }
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;
        //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        charC.Move(moveDir * Time.deltaTime);
    }
}
#endregion
