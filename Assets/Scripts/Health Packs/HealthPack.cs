using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPack : MonoBehaviour
{
    public event Action OnCollected = delegate { };

    private void OnTriggerEnter(Collider other) {
        OnCollected();
        gameObject.SetActive(false);
    }
}
