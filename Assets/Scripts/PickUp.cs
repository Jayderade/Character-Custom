using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Character Set Up/Interact")]
public class PickUp : MonoBehaviour {

    #region Variables
    //We are setting up these variable and the tags in update for week 3,4 and 5
    [Header("Player and Camera connection")]
    //create two gameobject variables one called player and the other mainCam
    public GameObject player;
    public GameObject mainCam;
    #endregion
    #region Start
    private void Start()
    {
        //Set the cursor to locked
        Cursor.lockState = CursorLockMode.Locked;
        //Set the Cursor to invisible
        Cursor.visible = false;
        //connect our player to the player variable via tag
        player = GameObject.FindGameObjectWithTag("Player");
        //connect our Camera to the mainCam variable via tag
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    #endregion
    #region Update
    private void Update()
    {
        //if our interact key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //create a ray
            Ray interact;
            //this ray is shooting out from the main cameras screen point center of screen
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //create hit info
            RaycastHit hitInfo;
            //if this physics raycast hits something within 10 units
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    //Debug that we hit a NPC
                    Debug.Log("Hit the NPC");
                    //grab the dialougue script off the NPC that we hit
                    Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();
                    //if that dialogue script exists on the NPC
                    if(dlg != null)
                    {
                        //turn the dialogue on and display it
                        dlg.showDlg = true;
                        //get the players mouselook script and turn it off
                        player.GetComponent<MouseLook>().enabled = true;
                        //get the players movement script and turn it off
                        player.GetComponent<Movement>().enabled = true;
                        //turn the camera's mouselook off
                        mainCam.GetComponent<MouseLook>().enabled = true;
                        //allow the cursor to move on screen
                        Cursor.lockState = CursorLockMode.None;
                        //and allow the cursor to be visible on screen
                        Cursor.visible = true;
                    }
                }
                #endregion
                #region Item
                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we hit an Item
                    Debug.Log("Hit an Item");
                }
                #endregion
            }
        }
    }
    #endregion
}
