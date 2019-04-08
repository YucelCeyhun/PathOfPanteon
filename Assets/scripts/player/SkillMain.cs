using UnityEngine;



public class SkillMain : MonoBehaviour {


    public bool spellState = true;
    public float coolDown;
    public float timer;
    public SpellCreate playerSpell;


    void Awake()
    {
        SpellStart();
    }


    void Update()
    {
        TimeCounter();
    }

    void SpellStart()
    {
        coolDown = playerSpell.cooldown;
    }

    public void SlotSpellCast()
    {
        if (spellState)
        {
            PlayerSpellCaster caster = playerSpell.playerSpellCaster;
            caster.othersTrigger.DoThat();
            caster.mainTrigger.DoThat();
            spellState = false;
        }
    }


    void TimeCounter()
    {
        if (!spellState)
        {
            timer += Time.deltaTime;
        }

        if (timer >= coolDown)
        {
            spellState = true;
            timer = 0;
        }

    }
 
   
}
