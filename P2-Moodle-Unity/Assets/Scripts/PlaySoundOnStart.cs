using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip ClickSoundEffect, ToggleSoundEffect;

    public void ClickEffect()
    {
        SoundManager.Instance.PlaySound(ClickSoundEffect);
        
    }

    public void ToggleEffect()
    {
        SoundManager.Instance.PlaySound(ToggleSoundEffect);
    }

}