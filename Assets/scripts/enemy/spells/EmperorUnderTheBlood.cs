using UnityEngine;

public class EmperorUnderTheBlood : MonoBehaviour {

    const float ENEMY_DETECT_RANGE = 50f;
    GameObject player;
    //float minDistance = 5f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void MainTrigger()
    {
        anim.SetTrigger("UnderTheBlood");
        anim.SetBool("available", false);
    }

    void GoToPlayerBack()
    {
        int rand = Random.Range(0, 2);
        transform.parent.position = rand == 0 ? player.transform.position - (Vector3.back * 5f) : player.transform.position + (Vector3.back * 5f);
        transform.parent.LookAt(new Vector3(player.transform.position.x, transform.parent.position.y, player.transform.position.z));
    }


    void SkillSound(AudioClip clip)
    {
        SoundManager.singleton.PlaySound(clip);
    }

    void SkillEffect(GameObject effect)
    {
        GameObject go = Instantiate(effect);
        go.GetComponent<SpellCommonAction>().target = transform.parent.gameObject;
    }

    void Available()
    {
        anim.SetBool("available", true);
    }
}
