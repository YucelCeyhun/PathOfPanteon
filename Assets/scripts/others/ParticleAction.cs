using System.Collections;
using UnityEngine;

public class ParticleAction : MonoBehaviour {

    private PlayerGeneral pg;
    private EnemyGeneral eg;
    public GameObject Owner;
    public GameObject destroyParticle;
    public GameObject dmgUI;
    public AttackType attackType;

    [SerializeField]
    TagList targetTag;

    void Start()
    {
        StartCoroutine(Destroyer());
    }

    void OnTriggerEnter(Collider hitCol)
    {
        if(hitCol.gameObject != Owner && (hitCol.tag == "Enemy" || hitCol.tag == "Player"))
            DmgCollider(hitCol.gameObject,attackType);
    }


    void DmgCollider(GameObject targetEnemy,AttackType attackType)
    {
        if (targetEnemy.gameObject.tag == targetTag.ToString())
        {
            GetComponent<Collider>().enabled = false;
            if(targetTag.ToString() == "Enemy")
            {
                pg = Owner.GetComponent<PlayerGeneral>();
                eg = targetEnemy.GetComponent<EnemyGeneral>();
                var dmg = eg.ChangeHp(pg.offensive.normalAttack, attackType);
                DmgUI(dmg);
            }
            else
            {
                eg = Owner.GetComponent<EnemyGeneral>();
                pg = targetEnemy.GetComponent<PlayerGeneral>();
                pg.ChangeHp(eg.offensive.normalAttack, attackType);
            }
        }

        DestroyEffectAppear();
        Destroy(gameObject,0.15f);

    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void DestroyEffectAppear()
    {

        GameObject go = Instantiate(destroyParticle, transform.position,Quaternion.identity);
        
        go.transform.rotation = Quaternion.LookRotation(transform.forward);
    }

    void DmgUI(int dmg)
    {
        GameObject go = Instantiate(dmgUI, transform.position, Quaternion.identity);
        go.transform.GetComponentInChildren<TextMesh>().text = dmg.ToString();
        go.transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
