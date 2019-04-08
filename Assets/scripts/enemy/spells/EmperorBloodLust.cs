using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyGeneral))]
[RequireComponent(typeof(ScriptsSituations))]
public class EmperorBloodLust : Combat
{

    
    Animator anim;
    public GameObject ParticleEffect;
    public GameObject tail;
    public GameObject target;

    void Start()
    {
        anim = GetComponent<Animator>();
        scriptsSituations = GetComponent<ScriptsSituations>();
    }


    public void MainTrigger()
    {
        anim.SetTrigger("BloodLust");
        anim.SetBool("available", false);
    }

    public void OthersTrigger()
    {
        NormalAttackToTarget(target);
        Vector3 direction = (new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 30f);
    }


    void NormalAttackToTarget(GameObject hitTarget)
    {
        AttackToTarget(hitTarget, tail);
    }

    void NormalAttackEffect()
    {
        LinearParticleEffect(ParticleEffect, tail.transform,70f);
    }

    void NormalAttackResoult()
    {
        scriptsSituations.Situations(true);
    }

    void SkillSoundBloodLust(AudioClip clip)
    {
        SoundManager.singleton.PlaySound(clip);
    }

    void Available()
    {
        anim.SetBool("available", true);
    }


}
