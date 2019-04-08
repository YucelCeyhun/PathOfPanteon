using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class SkillSlot : MonoBehaviour,IDragHandler,IEndDragHandler {

    public GameObject reflectObject;
    private bool refState = true;
    public float coolDown;
    public SkillMain sMain;

    public SpellCreate playerSpell;
    Image spellIcon;


    void Start() {
        SpellStart();
    }

    void Update()
    {
        TimeCounter();
    }

    void SpellStart()
    {
        coolDown = playerSpell.cooldown;
        spellIcon = GetComponent<Image>();
        spellIcon.sprite = playerSpell.icon;
        transform.parent.GetComponent<Image>().sprite = playerSpell.icon;
    }


  
    public void OnDrag(PointerEventData eventData)
    {
        if (refState)
        {
            CreateReflectObject();
        }
    }

   public void CreateReflectObject()
    {

        GameObject go = Instantiate(reflectObject);
        go.GetComponent<SpellDrag>().targetSpell = gameObject;
        
        refState = false;

    }

  

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject clone = GameObject.FindGameObjectWithTag("cloneSlot");
        if (clone != null)
            Destroy(clone);

        refState = true;
    }


    void TimeCounter()
    {
        if (!sMain.spellState)
        {
            spellIcon.fillAmount = (sMain.timer / sMain.coolDown);
        }
    }
 
   
}
