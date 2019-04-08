using System.Collections;
using System.Collections.Generic;


public class EnemiesNames  {

    public static EnemiesNames singleton = new EnemiesNames();

    List<string> enemyNameList = new List<string>();

    public EnemiesNames()
    {
        enemyNameList.Add("Magnuma");
    }
}
