using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ResourceGatherer : MonoBehaviour
{
    public float maxWeight;
    public float currentWeight;

    public float commonProbability ;
    public float rareProbability;
    public float epicProbability;
    public float legendaryProbability;

    //[SerializeField] private GameObject maxWeightReachedPanel;
    [SerializeField] ItemScriptableObjectList i;
    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    public Button gatherButton;

    void Start()
    {
        items = i.item;
        gatherButton.onClick.AddListener(GatherResources);
    }

    void GatherResources()
    {
        if (currentWeight >= maxWeight)
        {
            ShowWeightLimitExceededPopup();
            return;
        }

        ItemRarity rarity = DetermineItemRarity();

        ItemScriptableObject item = SelectRandomItem(rarity);

        GameService.Instance.inventoryController.AddItem(item);

        currentWeight += item.Weight;
    }

    ItemRarity DetermineItemRarity()
    {
        float randomValue = 100*Random.value;

        if (randomValue < legendaryProbability)
        {
            return ItemRarity.Legendary;
        }
        else if (randomValue < epicProbability)
        {
            return ItemRarity.Epic;
        }
        else if (randomValue < rareProbability)
        {
            return ItemRarity.Rare;
        }
        else if (randomValue < commonProbability)
        {
            return ItemRarity.Common;
        }
        else
        {
            return ItemRarity.Very_Common;      
        }
    }

    ItemScriptableObject SelectRandomItem(ItemRarity rarity)
    {
        List<ItemScriptableObject> filteredItems = items.FindAll(item => item.Rarity == rarity);

        int randomIndex = Random.Range(0, filteredItems.Count);
        return filteredItems[randomIndex];
    }

    void ShowWeightLimitExceededPopup()
    {
        Debug.Log("max weigh resouce gather");
        //maxWeightReachedPanel.SetActive(true);

    }
}
