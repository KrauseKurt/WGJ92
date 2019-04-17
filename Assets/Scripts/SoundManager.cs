using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource aSource;

    public AudioClip selectMenu;
    public AudioClip moveMenu;
    public AudioClip[] monsterRoars;
    public List<AudioClip> destructionSounds = new List<AudioClip>();
    public AudioClip monsterLaunch;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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

    public void PlayMonsterLaunch()
    {
        aSource.PlayOneShot(monsterLaunch);
    }

    public void PlayRandomDestructionSound()
    {
        int rand = Random.Range(0,destructionSounds.Count);
        aSource.PlayOneShot(destructionSounds[rand]);
    }

    public void PlayRoar(bool player1)
    {
        if (player1)
        {
            aSource.PlayOneShot(monsterRoars[0]);
        }
        else
        {
            aSource.PlayOneShot(monsterRoars[1]);
        }
    }


}
