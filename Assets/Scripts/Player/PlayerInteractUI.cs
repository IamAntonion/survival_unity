using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameOgject;
    [SerializeField] private PlayerInteract playerInteract;

    private void Update()
    {
        if (playerInteract.GetInterectableObject() != null)
        {
            Show();
        } else
        {
            Hide();
        }
    }

    private void Show()
    {
        containerGameOgject.SetActive(true);
    }

    private void Hide()
    {
        containerGameOgject.SetActive(false);
    }
}
