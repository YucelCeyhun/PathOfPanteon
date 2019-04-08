using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SpellDrag : MonoBehaviour,IDropHandler
{
    const int SLOT_OFFSET = 12;
    private Transform myParent;
    private Sprite spellIcon;

    public GameObject targetSpell;
    public List<RectTransform> slotList;


    void Start()
    {
        SpellStart();
    }

    void Update()
    {
        IconPostion();
    }


    void SpellStart()
    {
        myParent = GameObject.Find("skillRow").transform;
        transform.SetParent(myParent);
        transform.localScale = Vector3.one;

        BoxingRectTransform();
        spellIcon = targetSpell.GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = spellIcon;
        
    }

    void BoxingRectTransform()
    {
        int i = 0;
        GameObject[] slotObjs = GameObject.FindGameObjectsWithTag("actionSlot");
        foreach (GameObject slotObj in slotObjs)
        {
            slotList[i] = slotObj.transform as RectTransform;
            i++;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        foreach (RectTransform slot in slotList)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(slot, Input.mousePosition))
            {
                slot.GetComponent<Image>().sprite = spellIcon;
                slot.parent.GetComponent<Image>().sprite = spellIcon;
                slot.GetComponent<SlotAction>().slotSpell = targetSpell;
                slot.GetComponent<SlotAction>().sMain = targetSpell.GetComponent<SkillSlot>().sMain;
            }
        }

        Destroy(gameObject);
    }

    void IconPostion()
    {
        transform.position = new Vector3(Input.mousePosition.x - SLOT_OFFSET, Input.mousePosition.y - SLOT_OFFSET);

       // bool maxPosition = Input.mousePosition.x > Screen.width || Input.mousePosition.y > Screen.height;
        //bool minPosition = Input.mousePosition.x < 0 || Input.mousePosition.y < 0;

        /*if (maxPosition || minPosition)
            Destroy(gameObject);*/
    }
}
