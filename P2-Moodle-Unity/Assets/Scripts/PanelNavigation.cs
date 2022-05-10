using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Rfv5M14ZoGY&t=813s&ab_channel=InfoGamer
public class PanelNavigation : MonoBehaviour
{
    //List of game objects accessible in the Unity inspector
    [SerializeField] GameObject[] panels;

    //
    public void PanelChange(GameObject activePanel)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        activePanel.SetActive(true);
    }
}
