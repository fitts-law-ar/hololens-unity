using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public event Action<string> OnAction;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void OnRoundButtonClick()
    {
        OnAction?.Invoke("round");
    }

    public void OnTestButtonClick()
    {
        OnAction?.Invoke("test");
    }
}