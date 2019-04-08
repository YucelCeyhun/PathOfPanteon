using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SelectedItem : MonoBehaviour,IPointerDownHandler {

    public int row = 0;
    public int col = 0;
    public RectTransform curSlot;
    public string itemName;
    public bool InvActive;
    public Transform invParent;
    private List<RectTransform> rects;
    private GameObject player;
    private bool focused;


    

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetInvActive();
        ConverToRect();

        if (InvActive)
        {
            ScriptActivator(false);
            GetComponent<RectTransform>().sizeDelta = new Vector2(col * 30f, row * 30f);
            focused = true;
        }
        else
        {
            PassiveSlotControl();
        }
 
    }

	void Update ()
    {
        
        if (focused && InvActive)
        {
            transform.position = new Vector3(Input.mousePosition.x - 15f, Input.mousePosition.y + 5f);
        }

    }

    void ActiveSlotControl()
    {
        foreach(RectTransform rect in rects)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
            {
                if (SlotStatues(rect))
                {
                    SlotStock(rect);
                    break;
                }
            }
        }
    }

    void PassiveSlotControl()
    {
        foreach (RectTransform rect in rects)
        {
            if (SlotStatues(rect))
            {
                PassiveSlotStock(rect);
            }
        }

    }

    bool SlotStatues(RectTransform rect)
    {
        int ind = rects.IndexOf(rect);
         if (!(Calculator.FitCol(ind,col) && Calculator.FitRow(ind,row)))
             return false;

         int slotIndex = ind;
         for (int x = 0; x < row; x++)
         {
             slotIndex = ind + (20 * x);
             for (int y = 0; y < col; y++)
             {
                 if(!rects[slotIndex + y].GetComponent<InvSlot>().SlotSituation)
                     return false;
             }
         }
         
        return true;
    }

    void PassiveSlotStock(RectTransform rect)
    {
        int ind = rects.IndexOf(rect);
        int slotIndex = ind;
        for (int x = 0; x < row; x++)
        {
            slotIndex = ind + (20 * x);
            for (int y = 0; y < col; y++)
            {
                rects[slotIndex + y].GetComponent<InvSlot>().SlotSituation = false;
                rects[slotIndex + y].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
        }

        transform.SetParent(invParent);
        GetComponent<RectTransform>().sizeDelta = new Vector2(col * 30f, row * 30f);
        transform.localScale = Vector3.one;
        transform.position = rect.transform.position;
        curSlot = rect;
        rects = null;
    }

    void SlotStock(RectTransform rect)
    {
        int ind = rects.IndexOf(rect);
        int slotIndex = ind;
        for(int x = 0; x < row; x++)
        {
            slotIndex = ind + (20 * x);
            for (int y = 0; y < col; y++)
            {
                rects[slotIndex + y].GetComponent<InvSlot>().SlotSituation = false;
                rects[slotIndex + y].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
        curSlot = rect;
        transform.position = rect.transform.position;
        focused = false;
        ScriptActivator(true);
        rects = null;
    }


    void UnSlotStock(RectTransform rect)
    {
        ConverToRect();
        int ind = rects.IndexOf(rect);
        int slotIndex = ind;
        for (int x = 0; x < row; x++)
        {
            slotIndex = ind + (20 * x);
            for (int y = 0; y < col; y++)
            {
                rects[slotIndex + y].GetComponent<InvSlot>().SlotSituation = true; ;
                rects[slotIndex + y].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
        curSlot = null;
        focused = true;
    }

    void ConverToRect()
    {
        rects = player.GetComponent<ItemPickUp>().invSlotList;
    }

    void GetInvActive()
    {
        InvActive = player.GetComponent<ItemPickUp>().invPanel.gameObject.activeSelf;
    }

    void ScriptActivator(bool val)
    {

        player.GetComponent<ScriptsSituations>().Situations(val);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!focused && curSlot != null)
        {
            GetInvActive();
            UnSlotStock(curSlot);
        }
        else
        {
            ActiveSlotControl();
            DropItem di = GetComponent<DropItem>();
            di.CheckInvParent();
        }
    }

}
