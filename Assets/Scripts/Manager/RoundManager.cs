using System;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject button;

    public event Action OnAction;

    private RectTransform buttonRect;

    private void Start()
    {
        panel.SetActive(false);
        buttonRect = button.GetComponent<RectTransform>();
    }

    public void Show(Position startPosition)
    {
        panel.SetActive(true);
        UpdatePosition(startPosition);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void UpdatePosition(Position position)
    {
        SetButtonPosition(position);
        SetPanelDepth(position.z);
    }

    public void ConfirmAction()
    {
        OnAction?.Invoke();
    }

    private void SetButtonPosition(Position position)
    {
        buttonRect.anchoredPosition = new Vector2(position.x, position.y);
        buttonRect.sizeDelta = new Vector2(position.width, position.height);
    }

    private void SetPanelDepth(float z)
    {
        Vector3 panelPosition = panel.transform.position;
        panelPosition.z = z;
        panel.transform.position = panelPosition;
    }
}