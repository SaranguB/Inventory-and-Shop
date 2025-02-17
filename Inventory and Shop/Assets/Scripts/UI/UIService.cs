using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{

    [SerializeField] private Toggle shopToggle;
    [SerializeField] private TextMeshProUGUI shoppOrInventoryText;

  
    private void Start()
    {

    }

    public void OnShopToggleChanged(bool isOn)
    {
        if (isOn == false)
        {
            EventService.Instance.OnShopToggledOnEvent.InvokeEvent();
            shoppOrInventoryText.text = "Shop";
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {

            EventService.Instance.OnInventoryToggledOnEvent.InvokeEvent();
            shoppOrInventoryText.text = "Inventory";
            EventSystem.current.SetSelectedGameObject(null);
        }
    }







}
