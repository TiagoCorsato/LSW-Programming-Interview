using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject sc_Menu;
    public GameObject sc_Hud;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        sc_Menu.SetActive(true);
        sc_Hud.SetActive(false);
        playerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ActivateMenu();
            playerMovement.enabled = false;
        }

        if(sc_Menu.activeSelf == false)
        {
            playerMovement.enabled = true;
        }
    }

    public void BT_Start()
    {
        ActivateMenu();
        playerMovement.enabled = true;
    }

    public void BT_Quit()
    {
        Application.Quit();
    }

    public void ActivateMenu()
    {
        sc_Menu.SetActive(!sc_Menu.activeSelf);
        sc_Hud.SetActive(!sc_Hud.activeSelf);
    }
}
