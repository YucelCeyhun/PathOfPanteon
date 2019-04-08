using UnityEngine;
public class Calculator {

    public static int ManaCalculator(int intelligence,short addManaPercent)
    {
        int statMana = 20 + intelligence * 3;
        int total = statMana + (statMana * addManaPercent / 100);
        return total;
    }

    public static int LifeCalculator(int vitality,short addLifePercent)
    {
        int statLife = 20 + vitality * 3;
        int total = statLife + (statLife * addLifePercent / 100);
        return total;
    }


    public static int RealDmgCalculate(int pureDmg,AttackType attackType,Defensive def)
    {

        int dmg = pureDmg;

        switch (attackType)
        {
            case AttackType.Normal:
                dmg = DmgCalculator.NormalDmgCalculator(pureDmg, def.armor);
                break;
            case AttackType.Fire:
                dmg = DmgCalculator.MagicDmgCalculator(pureDmg, def.res.fireResist);
                break;
            case AttackType.Lightning:
                dmg = DmgCalculator.MagicDmgCalculator(pureDmg, def.res.lightningResist);
                break;
            case AttackType.Cold:
                dmg = DmgCalculator.MagicDmgCalculator(pureDmg, def.res.coldResist);
                break;
            case AttackType.Poison:
                dmg = DmgCalculator.MagicDmgCalculator(pureDmg, def.res.poisonResist);
                break;
        }

        return dmg;
    }

    public static float SpeedMultiply(float PlayerOwn,float mainSpeed)
    {
        return PlayerOwn * mainSpeed; 
    }

    public static float HpManaRate(int curhp,int maxhp)
    {
        float rate = curhp / (float)maxhp;
        rate = Mathf.Abs(rate);
        rate = MyClamp(rate, 0, 1f);
        return rate;
    }

    //This method coded instead of Mathf.Clamp method
    public static float MyClamp(float val, float min, float max)
    {
        if (val < 0)
        {
            val = min;
        }
        else if (val > max)
        {
            val = max;
        }

        return val;
    }

    public static int PercentPureDmg(float percent,int pureDmg,float extraPercent)
    {
        int total = (int)(pureDmg * (percent + extraPercent) / 100);
        return total;
    }


    public static bool FitRow(int ind, int row)
    {
        return ind + ((row - 1) * 20) < 200;

    }

    public static bool FitCol(int ind, int col)
    {
        return ind + (col - 1) < (int)(20 * (Mathf.Floor(ind / 20f) + 1));
    }


}
