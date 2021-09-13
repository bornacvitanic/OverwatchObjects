using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private HealthPack healthPack;
    [SerializeField] private GameObject rechargeIndicator;
    [SerializeField] private float cooldown = 10;

    private float timeOfRespawn = 0;
    private bool spawned = true;

    private void OnEnable()
    {
        healthPack.OnCollected += StartRespawnTimer;
    }

    private void OnDisable() {
        healthPack.OnCollected -= StartRespawnTimer;
    }

    private void StartRespawnTimer(){
        rechargeIndicator.SetActive(true);
        timeOfRespawn=Time.time+cooldown;
        spawned=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < timeOfRespawn){
            SetRespawnIndicatorProgress();
        }else if (Time.time >= timeOfRespawn && !spawned)
        {
            rechargeIndicator.SetActive(false);
            SpawnPack();
        }
    }

    private void SetRespawnIndicatorProgress(){
        rechargeIndicator.GetComponent<MeshRenderer>().material.SetFloat("Vector1_Progress",1-(timeOfRespawn-Time.time)/cooldown);
    }

    private void SpawnPack(){
        healthPack.gameObject.SetActive(true);
        spawned=true;
    }
}
