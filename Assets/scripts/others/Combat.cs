using UnityEngine;

[RequireComponent(typeof(ScriptsSituations))]
public class Combat : MonoBehaviour {

    GameObject targetEnemy;
    public ScriptsSituations scriptsSituations;


    protected void LinearParticleEffect(GameObject effect, Transform startRegion,float velocityFactor)
    {
        GameObject go = Instantiate(effect, startRegion.position, startRegion.rotation);
        go.GetComponent<ParticleAction>().Owner = gameObject;
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * velocityFactor;
    }

    protected void AttackToTarget(GameObject hitTarget, float attackSpeed,PlayerAnimations animations)
    { 
        Vector3 enemyPostion;
        targetEnemy = hitTarget;
        enemyPostion = targetEnemy.transform.position;
        transform.LookAt(new Vector3(enemyPostion.x, transform.position.y, enemyPostion.z));
        animations.PlayerNormalAttack(attackSpeed);
        scriptsSituations.Situations(false);
    }

    protected void AttackToTarget(GameObject hitTarget,GameObject tail)
    {
        Vector3 enemyPostion;
        targetEnemy = hitTarget;
        enemyPostion = targetEnemy.transform.position;
        tail.transform.LookAt(enemyPostion + Vector3.up * 1.75f);
        //transform.LookAt(new Vector3(enemyPostion.x, transform.position.y, enemyPostion.z));
        scriptsSituations.Situations(false);
    }


}
