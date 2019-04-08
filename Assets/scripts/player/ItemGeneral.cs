using UnityEngine;
using System.Text.RegularExpressions;

public class ItemGeneral : MonoBehaviour {

    public Sprite Icon;
    public string ItemName = "Basic Sword";
    public string ItemIndex = "{3;2;3;5;2;50;}{1,20;0,0;0,0;0,0;}{0,0;0,0;0,0;0,0;}{0,0;0,0;0,0;0,0;}";
    public ItemGroup ItemGroup;
    public int Itemrow = 0;
    public int Itemcol = 0;
    
    void Start () {
        string filter = @"{(.*?)}+";
        string filter2 = @"(\d+);+";
        string filter3 = @"(\d+),(\d+);+";
        string[] item = Regex.Split(ItemIndex, filter);
        string itemGeneral = item[1];
        string itemOffensive = item[3];
        string itemDefensive = item[5];
        string itemFunctional = item[7];

        string[] generalAttr = Regex.Split(itemGeneral, filter2);
        string[] offensiveAttr = Regex.Split(itemOffensive, filter3);
        string[] defensiveAttr = Regex.Split(itemOffensive, filter3);
        string[] functionalAttr = Regex.Split(itemOffensive, filter3);
        SelectItemGroup(int.Parse(generalAttr[3]));
    }

    void SelectItemGroup(int group)
    {
        ItemGroup = (ItemGroup)group;
        if(ItemGroup == ItemGroup.weaponOne)
        {
            Itemrow = 3;
            Itemcol = 1;
        }else if (ItemGroup == ItemGroup.rings)
        {
            Itemrow = 1;
            Itemcol = 1;
        }else if(ItemGroup == ItemGroup.helmet)
        {
            Itemrow = 2;
            Itemcol = 2;
        }
    }
	
	
}
