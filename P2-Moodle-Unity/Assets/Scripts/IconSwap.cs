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
