using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//перестал работать интерактив
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ObjectInteractable objectInteractable))
                {
                    Debug.Log(objectInteractable);
                    objectInteractable.Interact();
                }
            }
        }
    }

    public ObjectInteractable GetInterectableObject()
    {
        List<ObjectInteractable> objectInteractableList = new List<ObjectInteractable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ObjectInteractable objectInteractable))
            {
                objectInteractableList.Add(objectInteractable);
            }
        }

        ObjectInteractable closestObjectInteractable = null;
        foreach (ObjectInteractable objectInteractable in objectInteractableList)
        {
            if (closestObjectInteractable == null)
            {
                closestObjectInteractable = objectInteractable;
            } else
            {
                if (Vector3.Distance(transform.position, objectInteractable.transform.position) < Vector3.Distance(transform.position, closestObjectInteractable.transform.position))
                {
                    closestObjectInteractable = objectInteractable;
                }
            }
        }
        return null;
    }
}
