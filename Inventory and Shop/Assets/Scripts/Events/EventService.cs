
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
    public EventController OnShopToggledOnEvent { get; private set; }
    public EventController OnInventoryToggledOnEvent { get; private set; }

    public EventService()
    {
        OnShopToggledOnEvent = new EventController();
        OnInventoryToggledOnEvent = new EventController();
    }


}