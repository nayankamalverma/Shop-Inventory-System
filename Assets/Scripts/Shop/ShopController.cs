using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] private Slot slotPrefab;
	[SerializeField] private Transform slotContainer;
	[SerializeField] private ItemInfo infoPanel;
	[SerializeField] private ItemScriptableObjectList allItems;

	[SerializeField] private Button allTypes;
	[SerializeField] private Button materials;
	[SerializeField] private Button weapons;
	[SerializeField] private Button consumables;
	[SerializeField] private Button tresures;
   
	private List<ItemScriptableObject> currentItems =  new List<ItemScriptableObject>(); 
	private List<Slot> slots = new List<Slot>();

	private void OnEnable()
	{
		allTypes.onClick.AddListener(() => PopulatePanel(allItems.item));
		materials.onClick.AddListener(() => SetItemType(ItemType.Materials));
		weapons.onClick.AddListener(() => SetItemType(ItemType.Weapons));
		consumables.onClick.AddListener(() => SetItemType(ItemType.Consumables));
		tresures.onClick.AddListener(() => SetItemType(ItemType.Treasure));
	}

	private void OnDisable()
	{
		allTypes.onClick.RemoveAllListeners();
		materials.onClick.RemoveAllListeners();
		weapons.onClick.RemoveAllListeners();
		consumables.onClick.RemoveAllListeners();
		tresures.onClick.RemoveAllListeners();
	}

	private void Start()
	{
		currentItems = allItems.item;
		PopulatePanel(currentItems);
	}

	private void PopulatePanel(List<ItemScriptableObject> items)
	{
		ClearSlots();
		foreach (var item in items) { 
			Slot slot = Instantiate(slotPrefab, slotContainer);
			slots.Add(slot);
			slot.SetItemShop(item);
			Button buttonComponent = slot.GetComponentInChildren<Button>();
			if (buttonComponent != null)
			{
				buttonComponent.onClick.RemoveAllListeners();
				buttonComponent.onClick.AddListener(() => ShowDescriptionPanel(slot.item));
			}
		}
	}

	private void ShowDescriptionPanel(ItemScriptableObject item)
	{
		if (item == null) return;
		infoPanel.gameObject.SetActive(true);
		infoPanel.ShowDescription(item);
		infoPanel.SetBuyActive();
	}

	private void ClearSlots()
	{
		foreach (Slot slot in slots)
		{
			Destroy(slot.gameObject);
		}
		slots.Clear();
	}

	private void SetItemType(ItemType type)
	{
		currentItems = allItems.item.Where(item => item.ItemType == type).ToList();
		PopulatePanel(currentItems);
	}
}
