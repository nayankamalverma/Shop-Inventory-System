using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    public ItemScriptableObject item {  get; private set; }
    public int quantity { get; private set; }

    public Slot()
    {
        item = null;
        quantity = 0;
    }

    private void Start()
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

    public void  setItem(ItemScriptableObject item)
    {
        this.item = item;
        quantity = 1;
        UpdateInfo();
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
