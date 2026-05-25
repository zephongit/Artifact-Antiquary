using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Image icon;

    private InventoryItem item;

    public void Setup(InventoryItem newItem)
    {
        item = newItem;

        icon.sprite = item.inventoryIcon;
    }

    public void OnClick()
    {
        InspectManager.Instance.OpenInspect(item);
    }
}