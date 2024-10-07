using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Slot InventorySlotPrefab;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private ItemScriptableObjectList ItemsList;
    [SerializeField] private ItemInfo infoPanel;

    //ui
    [SerializeField] private TextMeshProUGUI weightText;
    
    public float MaxWeight = 50;
    
    private int maxSlots = 24;
    private float currentWeight = 0;

    private List<Slot> slots = new List<Slot>();


    private void Start()
    {
        InstantiateSlots();
        currentWeight=0;
        UpdateWeight();
    }

    private void InstantiateSlots()
    {
        ClearSlots();
        for (int i = 0; i < maxSlots; i++) { 
            Slot slot = Instantiate(InventorySlotPrefab, itemContainer);
            slots.Add(slot);
            Button buttonComponent = slot.GetComponentInChildren<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners(); // Clear existing listeners
                buttonComponent.onClick.AddListener(()=> ShowDescriptionPanel(slot.item));// Add new listener
            }
        }

    }

    private void ShowDescriptionPanel(ItemScriptableObject item)
    {
        if (item == null) return;
        infoPanel.gameObject.SetActive(true);
        infoPanel.ShowDescription(item);
        infoPanel.SetSellActive();
    }

    private void ClearSlots()
    {
        foreach (Slot slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
    }

    public bool AddItem(ItemScriptableObject item)
    {
        float totalWeight = item.Weight + currentWeight;
        if (totalWeight <= MaxWeight)
        {
            Slot slot = Contains(item);
            if (slot != null)
                slot.AddQuantity(1);
            else
            {
                slot = GetEmptySlot();
                slot.SetItem(item);
            }
            currentWeight += item.Weight;
            string msg = "Item added to Inventory...";
            StartCoroutine(infoPanel.ActivateMessagePanel(msg));
        }
        else
        {
            string msg = "Can`t buy this item.\n Over weight limit!!!";
            StartCoroutine(infoPanel.ActivateMessagePanel(msg));
            return false;
        }
        UpdateWeight();
        return true;
    }

    public bool RemoveItem(ItemScriptableObject item)
    {
        Slot temp = Contains(item);
        if (temp != null)
        {
            if (temp.quantity > 1)
                temp.SubQuantity(1);
            else
            {
                temp.RemoveItem();
                infoPanel.gameObject.SetActive(false);
            }
            currentWeight -= item.Weight;
            UpdateWeight();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool OnItemBuy(ItemScriptableObject item)
    {
        return AddItem(item);
    }

    private Slot GetEmptySlot()
    {
        return slots.Find(s => s.item == null);
    }

    public Slot Contains(ItemScriptableObject item)
    {
        return slots.Find(s => s.item == item);
    }

    private void UpdateWeight()
    {
        weightText.text = "Weight : " + currentWeight + " / 50 kg Max";
    }
}