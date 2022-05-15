using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSwap : MonoBehaviour
{
    [SerializeField] GameObject targetPanel;
    [SerializeField] GameObject startIcon;
    [SerializeField] GameObject selectedIcon;

    public void Update()
    {
        if (targetPanel.active)
        {
            selectedIcon.SetActive(true);
            startIcon.SetActive(false);
        }
        else
        {
            selectedIcon.SetActive(false);
            startIcon.SetActive(true);
        }
    }
}


//If statements in the update function runs it deactivates icons based on the active page panel
// Game objects for active page panel, as well as standard and selected icons on the navigation bar