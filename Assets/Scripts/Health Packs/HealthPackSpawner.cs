using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour, IInteract
{
    [SerializeField] private HealthPack healthPack;
    [SerializeField] private GameObject rechargeIndicator;
    [SerializeField] private GameObject hackedIndicator;
    [SerializeField] private float respawn_cooldown = 10;
    [SerializeField] private float hacked_cooldown = 30;

    private float timeOfRespawn = 0;
    private bool spawned = true;
    private float timeOfHackRecovery = 0;
    private bool hacked = false;

    private void OnEnable()
    {
        healthPack.OnCollected += StartRespawnTimer;
    }

    private void OnDisable() {
        healthPack.OnCollected -= StartRespawnTimer;
    }

    private void StartRespawnTimer(){
        rechargeIndicator.SetActive(true);
        timeOfRespawn = Time.time + respawn_cooldown;
        spawned=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hacked)
        {
            timeOfRespawn -= Time.deltaTime;
        }
        if(Time.time < timeOfRespawn){
            SetRespawnIndicatorProgress();
        }else if (Time.time >= timeOfRespawn && !spawned)
        {
            rechargeIndicator.SetActive(false);
            SpawnPack();
        }

        if(Time.time < timeOfHackRecovery)
        {
            SetHackIndicatorProgress();
        }
        else if(Time.time >= timeOfHackRecovery && hacked)
        {
            hackedIndicator.SetActive(false);
            hacked = false;
        }
    }

    private void SetRespawnIndicatorProgress(){
        rechargeIndicator.GetComponent<MeshRenderer>().material.SetFloat("Vector1_Progress", 1-(timeOfRespawn-Time.time) / respawn_cooldown);
    }

    private void SpawnPack(){
        healthPack.gameObject.SetActive(true);
        spawned=true;
    }

    private void SetHackIndicatorProgress()
    {
        hackedIndicator.GetComponent<MeshRenderer>().material.SetFloat("Vector1_Timeout", (timeOfHackRecovery - Time.time) / hacked_cooldown);
    }

    private void Hacked()
    {
        hackedIndicator.SetActive(true);
        hacked = true;
        timeOfHackRecovery = Time.time + hacked_cooldown;
    }

    public void Interact(GameObject origin)
    {
        if(!hacked)
        {
            Hacked();
        }
    }
}
