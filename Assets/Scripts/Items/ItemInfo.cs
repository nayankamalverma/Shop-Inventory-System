using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    //item info
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI type;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private TextMeshProUGUI weight;
    [SerializeField] private TextMeshProUGUI buyPrice;
    [SerializeField] private TextMeshProUGUI sellPrice;

    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI confirmationPriceText;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellConfirmButton;
    [SerializeField] private Button buyConfirmButton;
    [SerializeField] private Button cancelButton;

    private ItemScriptableObject item;

    private void OnEnable()
    {
        sellButton.onClick.AddListener(ActivateConfirmationPanelSell);
        buyButton.onClick.AddListener(ActivateConfirmationPanelBuy);
        sellConfirmButton.onClick.AddListener(OnItemSell);
        buyConfirmButton.onClick.AddListener(OnItemBuy);
        cancelButton.onClick.AddListener(DeactivateConfirmation);
    }

    public void ShowDescription(ItemScriptableObject item)
    {
        if (item != null)
        {
            this.item = item;
        }
        else
        {
            Debug.Log("Item Scriptable Object is Null");
        }

        if (item != null)
        {
            type.text = item.ItemType.ToString();
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
        sellConfirmButton.gameObject.SetActive(true);
        confirmationText.text = "Do you want to sell item?";
        confirmationPriceText.text = "Sell price : " + item.SellingPrice.ToString();
    }
    
    private void ActivateConfirmationPanelBuy()
    {
        if (GameService.Instance.coinController.Coins >= item.BuyingPrice)
        {
            confirmationPanel.SetActive(true);
            buyConfirmButton.gameObject.SetActive(true);
            confirmationText.text = "Do you want to Buy item?";
            confirmationPriceText.text = "Buy price : "+ item.BuyingPrice.ToString();
        }
        else
        {
            string msg = "insufficient Coins!!!!.. ";
            StartCoroutine(ActivateMessagePanel(msg));
        }
        
    }

    private void DeactivateConfirmation()
    {
        buyConfirmButton.gameObject.SetActive (false);
        sellConfirmButton.gameObject.SetActive(false);
        confirmationPanel.SetActive(false);
    }

    private void OnItemSell()
    {
        bool isItemRemoved = GameService.Instance.inventoryController.RemoveItem(item);
        if(isItemRemoved)GameService.Instance.coinController.AddCoins(item.SellingPrice);
        DeactivateConfirmation();
    }

    private void OnItemBuy() {
        
        bool isItemAdded = GameService.Instance.inventoryController.OnItemBuy(item);
        if (isItemAdded)
        {
            GameService.Instance.coinController.DeductCoins(item.BuyingPrice);
        }
        DeactivateConfirmation() ;
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

    public IEnumerator ActivateMessagePanel(string msg)
    {
        messagePanel.SetActive(true);
        messageText.text = msg;
        yield return new WaitForSeconds(1f);
        messagePanel.SetActive(false);
    }
}
