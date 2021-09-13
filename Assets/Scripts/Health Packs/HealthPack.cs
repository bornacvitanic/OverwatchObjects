using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        gameObject.SetActive(false);
        Debug.Log("Test");
    }
}
