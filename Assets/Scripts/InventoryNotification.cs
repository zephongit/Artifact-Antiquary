using UnityEngine;
using TMPro;
using System.Collections;

public class UIInventoryNotification : MonoBehaviour
{
    public static UIInventoryNotification Instance;

    public GameObject panel;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message));
    }

    private IEnumerator ShowRoutine(string message)
    {
        panel.SetActive(true);
        text.text = message;

        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
    }
}