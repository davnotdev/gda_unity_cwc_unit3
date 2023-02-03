using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player_rb;
    public float jump_force = 10.0f;
    public float gravity_modifier = 1.5f;
    public bool is_grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity_modifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        {
            player_rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            is_grounded = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        is_grounded = true;
    }
}
