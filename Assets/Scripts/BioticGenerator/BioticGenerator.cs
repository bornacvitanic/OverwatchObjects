using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioticGenerator : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject bioticField;
    [SerializeField] private GameObject flapController;
    [SerializeField] private int timeout = 10;
    [SerializeField] private float flapExtensionTime = 0.25f;
    private bool active = false;
    private float timeOfTimeout = 0;
    private Vector3 flapControllerDefaultPosition;
    private Vector3 flapControllerCurrentPosition;
    private Vector3 flapControllerTargetPosition;
    private float flapChangeTime;

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
        flapControllerCurrentPosition = flapController.transform.localPosition;
        flapControllerTargetPosition = flapControllerDefaultPosition - new Vector3(0, 0.77f, 0);
        flapChangeTime = Time.time;
    }

    private void DisableField()
    {
        active = false;
        bioticField.SetActive(false);
        flapControllerCurrentPosition = flapController.transform.localPosition;
        flapControllerTargetPosition = flapControllerDefaultPosition;
        flapChangeTime = Time.time;
    }

    private void Start()
    {
        flapControllerDefaultPosition = flapController.transform.localPosition;
        flapControllerCurrentPosition = flapController.transform.localPosition;
        flapControllerTargetPosition = flapControllerDefaultPosition;
        DisableField();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfTimeout && active)
        {
            DisableField();
        }
        if((Time.time - flapChangeTime) / flapExtensionTime <= 1)
        {
            flapController.transform.localPosition = Vector3.Lerp(flapControllerCurrentPosition, flapControllerTargetPosition, (Time.time - flapChangeTime) / flapExtensionTime);
        }
    }
}
