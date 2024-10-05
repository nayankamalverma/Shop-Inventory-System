
public class EventService
{

    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController<ItemScriptableObject> OnItemBuy { get; private set; }
    public EventController<ItemScriptableObject> OnItemSell { get; private set; }

    public EventController OnItemDescriptionShow { get; private set; }

    public EventService()
    {
        OnItemBuy = new EventController<ItemScriptableObject>();
        OnItemSell = new EventController<ItemScriptableObject>();
        OnItemDescriptionShow = new EventController();

    }
}