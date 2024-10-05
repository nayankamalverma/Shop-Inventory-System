using UnityEngine;

public class GameService : MonoBehaviour 
{
    public InventoryController inventoryController;
    public ShopController shopController;
    public CoinController coinController;

    public static GameService Instance { get { return instance; }}
    private static GameService instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
