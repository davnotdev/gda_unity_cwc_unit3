using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player_rb;
    private Animator player_animator;
    private AudioSource player_audio;

    public AudioClip player_jump_sound;
    public AudioClip player_bump_sound;

    public ParticleSystem player_bump_particles;
    public ParticleSystem player_dirt_particles;

    public bool game_over = false;
    public float jump_force = 10.0f;
    public float gravity_modifier = 1.8f;
    public bool is_grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        player_animator = GetComponent<Animator>();
        player_audio = GetComponent<AudioSource>();
        Physics.gravity *= gravity_modifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded && !game_over)
        {
            player_animator.SetTrigger("Jump_trig");
            player_rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            is_grounded = false;
            player_dirt_particles.Stop();
            player_audio.PlayOneShot(player_jump_sound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !game_over)
        {
            player_dirt_particles.Play();
            is_grounded = true;
        }
        else if (other.gameObject.CompareTag("Obsticle"))
        {
            game_over = true;
            Debug.Log("Game Over");
            player_animator.SetBool("Death_b", true);
            player_animator.SetInteger("DeathType_int", 1);
            player_bump_particles.Play();
            player_dirt_particles.Stop();
            player_audio.PlayOneShot(player_bump_sound, 1.0f);
        }
    }
}
