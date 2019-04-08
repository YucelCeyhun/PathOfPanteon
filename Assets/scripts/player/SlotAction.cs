using UnityEngine;
using UnityEngine.UI;

public class SlotAction : MonoBehaviour {

    public KeyCode kcode;
    public GameObject slotSpell;
    public SkillMain sMain;

    
    bool spellState;

  
	
	void Update ()
    {
        if (slotSpell != null)
        {
            KeyControl();
            GetIconFillAmount();
        }
    }

    void KeyControl()
    {
        if (Input.GetKeyDown(kcode))
        {
            sMain.SlotSpellCast();
        }
    }

    void GetIconFillAmount()
    {
        spellState = sMain.spellState;
        if (!spellState)
            GetComponent<Image>().fillAmount = sMain.timer / sMain.coolDown;
    }
}
