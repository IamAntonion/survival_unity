using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    [SerializeField] private float recoveryUnit = 20.0f;
    //private Interaction _interaction;
    //public GameObject player;

    private void Start()
    {
        //_interaction = player.GetComponent<Interaction>();
    }

    public void Interact()
    {
        //_interaction.HungryVoid(recoveryUnit);
        Debug.Log("Interact");
        Object.Destroy(this);
    }
}
