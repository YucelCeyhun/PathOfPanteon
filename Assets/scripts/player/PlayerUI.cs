using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerUI : MonoBehaviour {

    public static PlayerUI singleton;

    [SerializeField]
    List<GameObject> UIObjects;

    Image enemyHpBarImg;
    Image playerHpBarImg;

    Text enemyHpBarText;
    
    const float MAX_HP_BAR_IMG_WIDTH = 428f;



    void PlayerUIStarter()
    {
        Transform playerHpBar = UIObjects[1].transform.GetChild(0);
        playerHpBarImg = playerHpBar.GetComponent<Image>();
        Transform hpBar = UIObjects[0].transform.GetChild(0);
        enemyHpBarImg = hpBar.GetComponent<Image>();
        Transform enemyText = UIObjects[0].transform.GetChild(1);
        enemyHpBarText = enemyText.GetComponent<Text>();

    }
    /* toggle system for EnmeyHpBar */
    public void ShowEnemyHpBar()
    {
        if (!UIObjects[0].activeSelf)
            UIObjects[0].SetActive(true);
    }

    public void HideEnemyHpBar()
    {
        if(UIObjects[0].activeSelf)
            UIObjects[0].SetActive(false);
    }

    public void ChangeEnemyHpUI(float rate)
    {
        enemyHpBarImg.fillAmount = rate;
    }

    public void ChangePlayerHpUI(float rate)
    {
        playerHpBarImg.fillAmount = rate;
    }

    public void GetEnemyName(string name, EnemyType enemyType)
    {
        enemyHpBarText.text = name;
        TextStillChanger(enemyType);
    }

    void TextStillChanger(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Normal:
                enemyHpBarText.color = Color.white;
                enemyHpBarText.fontStyle = FontStyle.Normal;
                enemyHpBarText.fontSize = 18;
                break;
            case EnemyType.Rare:
                enemyHpBarText.color = Color.blue;
                enemyHpBarText.fontStyle = FontStyle.Bold;
                enemyHpBarText.fontSize = 20;
                break;
            case EnemyType.Elit:
                enemyHpBarText.color = Color.yellow;
                enemyHpBarText.fontStyle = FontStyle.Bold;
                enemyHpBarText.fontSize = 22;
                break;
            case EnemyType.Unique:
                enemyHpBarText.color = new Color(0.3396226f, 0.2147966f, 0.1265575f);
                enemyHpBarText.fontStyle = FontStyle.Bold;
                enemyHpBarText.fontSize = 22;
                break;
        }
    }

    void Awake()
    {
        PlayerUIStarter();
        singleton = this;
    }
}
