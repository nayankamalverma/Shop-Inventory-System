using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    public ItemScriptableObject item {  get; private set; }
    public int quantity { get; private set; }

    private void Awake()
    {
        RemoveItem();
    }

    public void RemoveItem()
    {
        item = null ;
        quantity = 0;
        icon.enabled = false;
        quantityText.enabled = false;
    }

    public void  SetItem(ItemScriptableObject item)
    {
        if (item != null) 
        {
            this.item = item;
            quantity = 1;
            UpdateInfo();
        }else Debug.Log("item null");
    }

    public void SetItemShop(ItemScriptableObject item)
    {
        if (item != null)
        {
            this.item = item ;
            quantity = 1;
            icon.enabled = true;
            icon.sprite = item.Icon;
        }
    }

    private void UpdateInfo()
    {
        icon.enabled = true;
        quantityText.enabled= true;
        icon.sprite = item.Icon;
        quantityText.text = quantity.ToString();
    }

    private void UpdateQuantity()
    {
        quantityText.text = quantity.ToString();
    }

    public void AddQuantity(int quantity) { this.quantity += quantity; UpdateQuantity(); }

    public void SubQuantity(int quantity) { this.quantity -= quantity; UpdateQuantity(); }
}
