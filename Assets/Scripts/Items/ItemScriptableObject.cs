using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemScriptableObject", menuName ="ScriptableObject/NewItem")]
public class ItemScriptableObject :ScriptableObject
{
    public string Name;
    public ItemType ItemType;
    public Sprite Icon;
    public string ItemDescription;
    public float BuyingPrice;
    public float SellingPrice;
    public ItemRarity Rarity;
    public float Quantity;
    public float Weight;
}

[CreateAssetMenu(fileName = "ItemScriptableObjectList", menuName = "ScriptableObject/NewItemScriptableObjectList")]
public class ItemScriptableObjectList : ScriptableObject
{
    public List<ItemScriptableObject> item;
}