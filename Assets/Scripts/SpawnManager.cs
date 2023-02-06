using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn_prefab;
    public float start_delay = 2;
    public float repeat_rate = 2;
    private Vector3 spawn_position = new Vector3(25, 0, 0);
    private PlayerController player_controller;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", start_delay, repeat_rate);
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObsticle() 
    {
        if (!player_controller.game_over)
        {
           Instantiate(spawn_prefab, spawn_position, spawn_prefab.transform.rotation);
        }
    }
}
