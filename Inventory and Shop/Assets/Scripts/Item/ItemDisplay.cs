using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemProperty itemProperty;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private Toggle itemToggle;
    private ToggleGroup itemToggleGroup;


    public void DisplayUI()
    {
        itemToggleGroup = GetComponentInParent<ToggleGroup>();
        itemToggle.group = itemToggleGroup;

        itemImage.sprite = itemProperty.itemIcon;
        quantity.text = itemProperty.quantity.ToString();
    }
}
