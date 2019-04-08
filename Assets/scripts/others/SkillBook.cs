using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook: MonoBehaviour {

    
    void PlaySoundEffect(AudioClip clip)
    {
        SoundManager.singleton.PlaySound(clip);
    }


}
