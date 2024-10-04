
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button removeButton;
    public ItemScriptableObject item {  get; private set; }
    public int quantity { get; private set; }

    public Slot()
    {
        item = null;
        quantity = 0;
    }

    private void Start()
    {
        icon.enabled = false;
        quantityText.enabled = false;
        removeButton.gameObject.SetActive(false);
    }

    public void  setItem(ItemScriptableObject item)
    {
        this.item = item;
        quantity = (int)item.Quantity;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        icon.enabled = true;
        quantityText.enabled= true;
        removeButton.gameObject.SetActive(true);
        icon.sprite = item.Icon;
        quantityText.text = quantity.ToString();
    }

    public void AddQuantity(int quantity) { this.quantity += quantity; }
    public void SubQuantity(int quantity) { this.quantity -= quantity; }

}
