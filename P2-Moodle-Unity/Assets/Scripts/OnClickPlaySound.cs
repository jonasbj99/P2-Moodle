using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OnClickPlaySound : MonoBehaviour {
	public Button[] buttons;

        [SerializeField] private AudioClip _clip;

	void Start () 
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button btns = buttons[i].GetComponent<Button>();
            btns.onClick.AddListener(TaskOnClick);
        }
	}

	void TaskOnClick(){
		Debug.Log ("A Button has been click and a sound should have played.");
        SoundManager.Instance.PlaySound(_clip);
	}
}