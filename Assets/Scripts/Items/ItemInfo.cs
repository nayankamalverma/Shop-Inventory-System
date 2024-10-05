using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI type;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private TextMeshProUGUI weight;
    [SerializeField] private TextMeshProUGUI buyPrice;
    [SerializeField] private TextMeshProUGUI sellPrice;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button buyButton;

    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private TextMeshProUGUI confirmationPriceText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    private ItemScriptableObject item;

    private void OnEnable()
    {
        sellButton.onClick.AddListener(ActivateConfirmationPanelSell);
        buyButton.onClick.AddListener(ActivateConfirmationPanelBuy);
        confirmButton.onClick.AddListener(OnItemSell);
        cancelButton.onClick.AddListener(DeactivateConfirmation);
    }

    public void ShowDescription(ItemScriptableObject item)
    {
        if (item != null)
        {
            this.item = item;
            Debug.Log("Item: " + item);
        }
        else
        {
            Debug.Log("Item Scriptable Object is Null");
        }

        if (item != null)
        {
            name.text = item.Name;
            icon.sprite = item.Icon;
            description.text = item.ItemDescription;
            buyPrice.text = "Buy Price: " + item.BuyingPrice.ToString();
            sellPrice.text = "Sell Price: " + item.SellingPrice.ToString();
            weight.text = "Weight: " + item.Weight.ToString() + "kg";
            rarity.text = "Rarity: " + item.Rarity;
        }
    }

    private void ActivateConfirmationPanelSell()
    {
        confirmationPanel.SetActive(true);
        confirmationText.text = "Do you want to sell item?";
        confirmationPriceText.text = "Sell price : " + item.SellingPrice.ToString();
    }
    
    private void ActivateConfirmationPanelBuy()
    {
        confirmationPanel.SetActive(true);
        confirmationText.text = "Do you want to Buy item?";
        confirmationPriceText.text = "Buy price : "+ item.BuyingPrice.ToString();
    }

    private void DeactivateConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    private void OnItemSell()
    {
        bool isItemRemoved = GameService.Instance.inventoryController.RemoveItem(item);
        if(isItemRemoved)GameService.Instance.coinController.AddCoins(item.SellingPrice);
        DeactivateConfirmation();
    }

    public void SetSellActive()
    {
        buyButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(true);
    }

    public void SetBuyActive()
    {
        sellButton.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(true);
    }
}
