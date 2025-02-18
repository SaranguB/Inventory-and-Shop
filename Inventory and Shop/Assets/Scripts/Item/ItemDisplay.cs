using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemProperty itemProperty;

    public Image itemImage;

    public TextMeshProUGUI quantity;

    private void Start()
    {
        itemImage.sprite = itemProperty.itemIcon;
        quantity.text = itemProperty.quantity.ToString();
    }
}
