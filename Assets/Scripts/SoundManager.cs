using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource aSource;

    public AudioClip selectMenu;
    public AudioClip moveMenu;

    public void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void PlayMoveMenu()
    {
        aSource.PlayOneShot(moveMenu);
    }

    public void PlaySelectMenu()
    {
        aSource.PlayOneShot(selectMenu);
    }


}
