using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    private float Coins;

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