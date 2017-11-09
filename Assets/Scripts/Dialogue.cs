using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NPC/Dialogue")]
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDlg;
    //index for our current line of dialogu and an index for a set question marker of the dialogue 
    public int index, optionsIndex;
    //object reference to the player
    public GameObject player;
    //mouselook script reference for the maincamera
    public MouseLook mainCam;
    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public string npcName;
    //array for text for our dialogue
    public string[] text;
    #endregion
    #region Start
    void Start()
    {
        //find and reference the player object by tag
        player = GameObject.FindGameObjectWithTag("Player");
        //find and reference the maincamera by tag and get the mouse look component 
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
    }
    #endregion
    #region OnGUI
    void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDlg)
        {
            //set up our ratio messurements for 16:9
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0, 6 * scrH, Screen.width, 3 * scrH), npcName + ":" + text[index]);
            //if not at the end of the dialogue or not at the options part
            if (!(index + 1 >= text.Length || index == optionsIndex))
            {
                //next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Next"))
                {
                    index++;
                }
            }
            //else if we are at options
            else if (index == optionsIndex)
            {
                //Accept button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Accept"))
                {
                    index++;
                }
                //Decline button skips us to the end of the characters dialogue 
                if (GUI.Button(new Rect(14 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Decline"))
                {
                    index = text.Length - 1;
                }
            }
            //else we are at the end
            else
            {
                //the Bye button allows up to end our dialogue
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Bye."))
                {
                    //close the dialogue box
                    showDlg = false;
                    //set index back to 0 
                    index = 0;
                    //allow cameras mouselook to be turned back on
                    mainCam.enabled = true;
                    //get the component mouselook on the character and turn that back on
                    player.GetComponent<MouseLook>().enabled = true;
                    //get the component movement on the character and turn that back on
                    player.GetComponent<Movement>().enabled = true;
                    //lock the mouse cursor
                    Cursor.lockState = CursorLockMode.Locked;
                    //set the cursor to being invisible
                    Cursor.visible = false;
                }
            }
        }
        #endregion
    }
}
