using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efx;
    public static SoundManager singleton = null;

    void Awake()
    {
        if (singleton == null)
            singleton = this;

        DontDestroyOnLoad(gameObject);
    }


    public void PlaySound(AudioClip clip)
    {
        efx.clip = clip;
        efx.Play();
    }

    public void RandomPlaySound(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        efx.clip = clips[randomIndex];
        efx.Play();
    }

    
}
