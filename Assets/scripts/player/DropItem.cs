using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour {

    public RectTransform invParent;
    public bool focused;
    public GameObject itemInstance;

    const float ITEM_POS_OFFSET = 0.5f; 

    private void Start()
    {
        itemInstance = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/prefabs/models/item.prefab");
    }

    public void CheckInvParent()
    {
        invParent = GameObject.Find("equipment").transform as RectTransform;
        bool dropCheck = RectTransformUtility.RectangleContainsScreenPoint(invParent, Input.mousePosition);
        if (!dropCheck)
        {
            Dictionary<string, string> itemInfo = GetItemInfo();
            CreateDroppedItem(itemInfo);
        }
    }

    private Dictionary<string, string> GetItemInfo()
    {
        Dictionary<string, string> itemValues = new Dictionary<string, string>();
        Image itemImg = GetComponent<Image>();
        SelectedItem selectedItem = GetComponent<SelectedItem>();

        itemValues["name"] = selectedItem.itemName;
        itemValues["rowCol"] = selectedItem.row + "," + selectedItem.col;
        itemValues["pathName"] = itemImg.sprite.name;
        itemValues["path"] = "Assets/UI/ItemIcons/" + itemValues["pathName"] + ".png";

        return itemValues;
    }

    private void CreateDroppedItem(Dictionary<string,string> itemInfo)
    {
        Vector3 itemPostion = GetPlayerPosition();
        GameObject go = Instantiate(itemInstance, itemPostion, Quaternion.identity);
        ItemGeneral itemGeneral = go.GetComponent<ItemGeneral>();
        Sprite itemImage = AssetDatabase.LoadAssetAtPath<Sprite>(itemInfo["path"]);
        itemGeneral.ItemName = itemInfo["name"];
        itemGeneral.Icon = itemImage;
        Destroy(gameObject);
    }

    private Vector3 GetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        Vector3 itemPostion = new Vector3(playerPosition.x, playerPosition.y + ITEM_POS_OFFSET, playerPosition.z);
        return itemPostion;
    }
}
