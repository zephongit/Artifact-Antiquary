using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour

{
    public static InventoryManager Instance;

    public Transform itemContainer;

    public GameObject itemPrefab;

    private List<InventoryItem> items = new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);

        UIInventoryNotification.Instance.Show($"{item.itemName} added!");

        GameObject newItem = Instantiate(itemPrefab, itemContainer);

        newItem.GetComponent<InventoryButton>().Setup(item);
    }
}