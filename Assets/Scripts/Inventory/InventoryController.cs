using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Slot InventorySlotPrefab;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private ItemScriptableObjectList ItemsList;
    public Button addItem;
    
    public float MaxWeight = 50;
    
    private int maxSlots = 24;
    private int currentWeight = 0;

    private List<Slot> slots = new List<Slot>();

    private void OnEnable()
    {
        addItem.onClick.AddListener(AddItem);
    }

    private void OnDisable()
    {
        addItem.onClick?.RemoveListener(AddItem);   
    }

    private void Start()
    {
        InstantiateSlots();
    }

    private void InstantiateSlots()
    {
        ClearSlots();
        for (int i = 0; i < maxSlots; i++) { 
            Slot slot = Instantiate(InventorySlotPrefab, itemContainer);
            slots.Add(slot);
        }

    }

    private void ClearSlots()
    {
        foreach (Slot slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
    }

    public void AddItem()
    {
        slots[0].setItem(ItemsList.item[0]);
    }

}
