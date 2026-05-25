using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;

    public Sprite inventoryIcon;

    public Sprite enlargedView;

    public Sprite closeUpView;

    public Dialogue postInspectDialogue;

    [TextArea]
    public string description;

    public string closeUpDescription;
}