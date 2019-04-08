using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ItemPickUp : MonoBehaviour {

    public GameObject itemUIPrefabs;
    public Transform invParent;
    public Transform invPanel;
    public List<RectTransform> invSlotList;
    private GameObject itemUI;



    public void TakeItem(Transform Item)
    {
        ItemGeneral itemGeneral = Item.GetComponent<ItemGeneral>();
        if(invPanel.gameObject.activeSelf)
            GetComponent<ScriptsSituations>().Situations(false);

        CreateItemUI();
        MainStats(itemGeneral);

        if (itemUI != null)
            Destroy(Item.gameObject);
    }

    private void MainStats(ItemGeneral itemGeneral)
    {
        itemUI.GetComponent<SelectedItem>().itemName = itemGeneral.ItemName;
        itemUI.GetComponent<Image>().sprite = itemGeneral.Icon;
        itemUI.GetComponent<SelectedItem>().row = itemGeneral.Itemrow;
        itemUI.GetComponent<SelectedItem>().col = itemGeneral.Itemcol;
    }

    private void CreateItemUI()
    {
        if (invPanel.gameObject.activeSelf)
        {
            itemUI = Instantiate(itemUIPrefabs, invParent);
        }
        else
        {
            itemUI = Instantiate(itemUIPrefabs);
            itemUI.GetComponent<SelectedItem>().invParent = invParent;
        }
    }
}
