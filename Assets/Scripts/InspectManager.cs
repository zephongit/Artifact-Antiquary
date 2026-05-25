using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;

    public GameObject inspectPanel;
    public Image enlargedImage;
    public TextMeshProUGUI itemDescription;

    private InventoryItem currentItem;
    private bool isZoomed = false;

    private void Awake()
    {
        Instance = this;
        inspectPanel.SetActive(false);
    }

    public void OpenInspect(InventoryItem item)
    {
        currentItem = item;
        isZoomed = false;

        inspectPanel.SetActive(true);

        enlargedImage.sprite = item.enlargedView;
        itemDescription.text = item.description;
    }

public void ToggleInspectView()
{
    if (currentItem == null) return;

    isZoomed = !isZoomed;

    if (isZoomed)
    {
        enlargedImage.sprite = currentItem.closeUpView;
        itemDescription.text = currentItem.closeUpDescription;
    }
    else
    {
        enlargedImage.sprite = currentItem.enlargedView;
        itemDescription.text = currentItem.description;
    }
}

   public void CloseInspect()
{
    inspectPanel.SetActive(false);

    if (currentItem != null && currentItem.postInspectDialogue != null)
    {
        DialogueManager.Instance.StartDialogue(currentItem.postInspectDialogue, null);
    }

    currentItem = null;
}
}