using System;
using UnityEngine;
public static class DmgCalculator {


    const float MAX_NORMAL_DMG_REDUCTION_RATE = 0.95f;
    const float MAX_MAGIC_DMG_REDUCTION_RATE = 0.85f;

    public static int NormalDmgCalculator(int pureDmg,int armor)
    {
        float Armor = Calculator.MyClamp(armor, 1f, int.MaxValue);
        float fx = (float)(Math.Log(1.5f * Armor, Math.E) / Math.Log(int.MaxValue, Math.E));
        fx = Calculator.MyClamp(fx,0, MAX_NORMAL_DMG_REDUCTION_RATE);
        float result = pureDmg * (1 - fx);

        return (int)Mathf.Round(result + UnityEngine.Random.Range(-result / 10f, result / 10f));
    }

    public static int MagicDmgCalculator(int pureDmg,int res)
    {
        float percentRes = res / 100f;
        percentRes = Calculator.MyClamp(percentRes, 0, MAX_MAGIC_DMG_REDUCTION_RATE);
        int result = (int)(pureDmg * (1 - percentRes));
        return result;
    }

}
