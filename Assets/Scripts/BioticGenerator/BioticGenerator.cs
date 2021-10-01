using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioticGenerator : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject bioticField;
    [SerializeField] private int timeout = 10;
    private bool active = false;
    private float timeOfTimeout = 0;

    public void Interact(GameObject origin)
    {
        if(!active)
        {
            EnableField();
        }
        timeOfTimeout = Time.time + timeout;
    }

    private void EnableField()
    {
        active = true;
        bioticField.SetActive(true);
    }

    private void DisableField()
    {
        active = false;
        bioticField.SetActive(false);
    }

    private void Start()
    {
        DisableField();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfTimeout && active)
        {
            DisableField();
        }
    }
}
