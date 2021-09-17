using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject shield;
    [SerializeField] private List<GameObject> effects;
    [SerializeField] private Animator animator;
    [SerializeField] private int timeout = 10;
    private bool active = false;
    private float timeOfTimeout = 0;

    public void Interact(GameObject origin)
    {
        if(!active)
        {
            EnableShield();
        }
        timeOfTimeout = Time.time + timeout;
    }

    private void EnableShield()
    {
        active = true;
        shield.SetActive(true);
        foreach(var effect in effects)
        {
            effect.SetActive(true);
        }
        animator.enabled = true;
    }

    private void DisableShield()
    {
        active = false;
        shield.SetActive(false);
        foreach(var effect in effects)
        {
            effect.SetActive(false);
        }
        animator.enabled = false;
    }

    private void Start()
    {
        DisableShield();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfTimeout && active)
        {
            DisableShield();
        }
    }
}
