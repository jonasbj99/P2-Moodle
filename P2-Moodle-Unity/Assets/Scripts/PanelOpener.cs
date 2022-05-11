using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    //Defining the panel gameobject
    public GameObject Panel;

    public void OpenPanel()
    {
        //Checking if the panel is assigned to the button. If it is, the panel is set to active meaning it becomes visible.
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    
}

//Lavet vha. youtube tutorial: https://www.youtube.com/watch?v=LziIlLB2Kt4
