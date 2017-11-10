using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
    public bool showInv;
    public Item selectedItem;
    public int money;
    public GameObject wHand, curWeapon;
    public Movement playerMove;
    public MouseLook mainCam, playerCam; 
    public Vector2 scrollPos;
    // Use this for initialization
    void Start()
    {
        playerCam = this.GetComponent<MouseLook>();
        playerMove = this.GetComponent<Movement>();
        wHand = GameObject.FindGameObjectWithTag("Weapon Handler");

        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(208));
        inv.Add(ItemGen.CreateItem(700));
        inv.Add(ItemGen.CreateItem(701));
        inv.Add(ItemGen.CreateItem(800));

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            //turn back on char and cam movement/mouselock
            gameObject.GetComponent<Movement>().enabled = false;
            gameObject.GetComponent<MouseLook>().enabled = true;
            //lock and hide our cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            //turn back on char and cam movement/mouselock
            gameObject.GetComponent<Movement>().enabled = true;
            gameObject.GetComponent<MouseLook>().enabled = false;
            //lock and hide our cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            return (true);
        }
    }
    void OnGUI()
    {
        if(showInv)
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            // Background for inventory labled Inventory
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            // if less than or equal to x items no scroll view
            if(inv.Count <= 35)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH + i * (0.25f * scrH), 3 * scrW, 0.25f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            // if more than we can scroll and add the same space according to the number of shit we have
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0,0,6*scrW,9*scrH),scrollPos, new Rect(0,0,0,9*scrH + ((inv.Count - 35)*0.25f*scrH)),false,true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH + i * (0.25f * scrH), 3 * scrW, 0.25f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
                GUI.EndScrollView();
            }
            if(selectedItem != null)
            {
                if(selectedItem.Type == ItemType.Food)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if(GUI.Button(new Rect(15*scrW,8.75f*scrH,scrW,0.25f*scrH),"Eat"))
                    {
                        Debug.Log("Yum I love " + selectedItem.Name);
                        inv.Remove(selectedItem);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Weapon)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, 0.25f * scrH), "Equip"))
                    {
                         Debug.Log("I will swing this Mighty " + selectedItem.Name);   
                         if(curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }                    
                         curWeapon = Instantiate(Resources.Load("Prefabs/"+selectedItem.Mesh)as GameObject, wHand.transform.position,wHand.transform.rotation,wHand.transform);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Apparel)
                {

                }
                if (selectedItem.Type == ItemType.Crafting)
                {

                }
                if (selectedItem.Type == ItemType.Quest)
                {

                }
                if (selectedItem.Type == ItemType.Ingredients)
                {

                }
                if (selectedItem.Type == ItemType.Potions)
                {

                }
                if (selectedItem.Type == ItemType.Scrolls)
                {

                }
            }
        }
    }
}
