using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private float left_bound = -15.0f;
    private PlayerController player_controller;

    // Start is called before the first frame update
    void Start()
    {
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_controller.game_over)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < left_bound && gameObject.CompareTag("Obsticle"))
        {
            Destroy(gameObject);
        }
    }
}
