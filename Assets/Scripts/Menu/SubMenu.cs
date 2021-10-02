using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{

    GameObject rootMenu;
    public void OpenSubMenu(GameObject rootMenu)
    {
        gameObject.SetActive(true);
        this.rootMenu = rootMenu;
        rootMenu.gameObject.SetActive(false);
    }

    public void CloseSubMenu()
    {
        gameObject.SetActive(false);
        rootMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseSubMenu();
    }
}
