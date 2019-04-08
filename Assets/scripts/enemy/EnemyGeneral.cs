using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneral : MonoBehaviour
{
    
    public string curLifePrint;
    public string lifePrint;
    public Source enemySource;
    public Defensive defensive;
    public EnemyInfo emeyInfo;
    public Offensive offensive;
    public List<SpellCaster> spellCasters;
    private Animator anim;
    int life;
    public int Life
    {
        get { return life; }
    }

    int curlife;
    public int curLife
    {
        get { return curlife; }
        set { curlife = value; }
    }

    void LifePrint()
    {
        LifeStart();
        lifePrint = Life.ToString();
    }

    void CurLifePrint()
    {
        curLifePrint = curLife.ToString();
    }

    void LifeStart()
    {
        life = enemySource.life;
        curlife = enemySource.life;
    }

    void CurLife(int realDmg)
    {
        curlife -= realDmg;
        curlife = (int)Calculator.MyClamp(curlife, 0, int.MaxValue);
    }

    public int ChangeHp(int dmg, AttackType attackType)
    {
        int realDmg = Calculator.RealDmgCalculate(dmg, attackType,defensive);
        CurLife(realDmg);
        return realDmg;
    }

    void ChangeHpUI()
    {
        float hpRate = Calculator.HpManaRate(curLife, Life);
        PlayerUI.singleton.ChangeEnemyHpUI(hpRate);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        LifePrint();
        
    }
    void Update()
    {
        spellCasters[0].SpellCast(anim.GetBool("available"));
        spellCasters[1].SpellCast(anim.GetBool("available"));
        CurLifePrint();
    }


    void OnMouseOver()
    {
        ChangeHpUI();
    }

    void OnMouseEnter()
    {
        PlayerUI.singleton.ShowEnemyHpBar();
        PlayerUI.singleton.GetEnemyName(emeyInfo.name,emeyInfo.enemyType);
    }

    void OnMouseExit()
    {
        PlayerUI.singleton.HideEnemyHpBar();
    }

}