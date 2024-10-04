using UnityEngine;

public class GameService : MonoBehaviour 
{
    [SerializeField] InventoryController inventoryController;
    [SerializeField] ShopController shopController;
    [SerializeField] CoinController coinController;

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
