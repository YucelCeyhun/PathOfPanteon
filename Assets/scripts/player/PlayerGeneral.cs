using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{

    public Stats PlayerStats;
    public string manaPrint;
    public string lifePrint;
    public string curLifePrint;
    public string curManaPrint;
    public Source playerSource;
    public Defensive defensive;
    public Offensive offensive;
    public int PlayerLevel;

    int mana;
    public int Mana
    {
        get { return mana; }
    }

    int life;
    public int Life
    {
        get { return life; }
    }

    int curlife;
    public int curLife
    {
        get { return curlife; }
    }

    int curmana;
    public int curMana
    {
        get { return curmana; }
    }

    void LifeManaCalculate()
    {
        playerSource.life = Calculator.LifeCalculator(PlayerStats.vitality, 0);
        playerSource.mana = Calculator.ManaCalculator(PlayerStats.intelligence, 0);
    }


    void LifeManaPrint()
    {
        LifeManaStart();
        lifePrint = Life.ToString();
        manaPrint = Mana.ToString();
    }

    void CurLifeManaPrint()
    {
        curLifePrint = curLife.ToString();
        curManaPrint = curMana.ToString();
    }

    void LifeManaStart()
    {
        life = playerSource.life;
        mana = playerSource.mana;
        curlife = playerSource.life;
        curmana = playerSource.mana;
    }

    void CurLife(int realDmg)
    {
        curlife -= realDmg;
        curlife = (int)Calculator.MyClamp(curlife, 0, int.MaxValue);
    }

    public void ChangeHp(int dmg, AttackType attackType)
    {
        int realDmg = Calculator.RealDmgCalculate(dmg, attackType, defensive);
        CurLife(realDmg);
    }

    void ChangeHpUI()
    {
        float hpRate = Calculator.HpManaRate(curLife, Life);
        float manaRate = Calculator.HpManaRate(curMana, Mana);
        PlayerUI.singleton.ChangePlayerHpUI(hpRate);
    }


    void Start()
    {
        LifeManaCalculate();
        LifeManaPrint();
    }

    void Update()
    {
        CurLifeManaPrint();
        ChangeHpUI();
    }
}




    


