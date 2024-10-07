using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    public float Coins {  get; private set; }
    private void Update()
    {
        UpdateCoins();
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }

    public bool DeductCoins(float amount)
    {

        Coins -= amount;
        return true;
    }

    public void UpdateCoins()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins : " + Coins.ToString();
        }
    }


}