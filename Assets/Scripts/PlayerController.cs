using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animplayer;
    public ParticleSystem expSystem;
    public ParticleSystem dirtParticles;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource asPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        //Physics.gravity = Physics.gravity * gravityModifier;

        animplayer = GetComponent<Animator>();

        asPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        //Conditions met to jump:
        if (spaceDown && onGround && !gameOver)
        {
            rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            animplayer.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            asPlayer.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticles.Play();
        }
        //Game's over with this condition achieved
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            Debug.Log("Game Over");
            gameOver = true;
            animplayer.SetBool("Death_b", true);
            animplayer.SetInteger("DeathType_int", 2);
            expSystem.Play();
            dirtParticles.Stop();
            asPlayer.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
