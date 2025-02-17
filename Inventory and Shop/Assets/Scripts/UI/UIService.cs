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
            GameManager.Instance.inventoryController.DisableInventoryVisibility();
            GameManager.Instance.shopController.EnableShopVisibility();
            shoppOrInventoryText.text = "Shop";
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
           
            GameManager.Instance.shopController.DisableShopVisibility();
            GameManager.Instance.inventoryController.EnableInventoryVisibility();
            shoppOrInventoryText.text = "Inventory";
            EventSystem.current.SetSelectedGameObject(null);
        }
    }







}
