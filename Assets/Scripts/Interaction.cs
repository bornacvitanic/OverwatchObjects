using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public void Interact(IInteract target)
    {
        target.Interact(gameObject);
    }

    public void InteractRaycast()
    {
        RaycastHit objectHit;
        Debug.DrawRay(transform.position, transform.forward*15f, Color.green);
        if(Physics.Raycast(transform.position, transform.forward, out objectHit, 15f))
        {
            if(objectHit.transform.TryGetComponent<IInteract>(out IInteract interactable))
            {
                interactable.Interact(gameObject);
            }
        }
        
    }
}

public interface IInteract
{
    void Interact(GameObject origin);
}
