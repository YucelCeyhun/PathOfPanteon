using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerGeneral))]
public class PlayerCombat : Combat {


    PlayerAnimations animations;
    PlayerGeneral pg;

    public List<GameObject> ParticleEffects;
    public GameObject tail;


	void Start () {
        pg = GetComponent<PlayerGeneral>();
        animations = GetComponent<PlayerAnimations>();
        scriptsSituations = GetComponent<ScriptsSituations>();
    }

    public void NormalAttackToTarget(GameObject hitTarget)
    {
        AttackToTarget(hitTarget, pg.offensive.attackSpeed, animations);
    }

    public void NormalAttackEffect()
    {
        LinearParticleEffect(ParticleEffects[0], tail.transform,20f);
    }

    public void NormalAttackResoult()
    {
        scriptsSituations.Situations(true);
    }
    

    
}
