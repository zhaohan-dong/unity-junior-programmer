using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool gameOver = false; // Gameover flag
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Rigidbody playerRb; // Player rigidbody
    private Animator playerAnim; // Player animation controller
    private AudioSource playerAudio; // Add audio to player
    private bool isOnGround = true; // On ground boolean to control jump

    // Start is called before the first frame update
    void Start()
    {
        // Get components from Player
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        // Modify gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump if spacebar pressed on ground and not game over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig"); // Set jump trigger in animation
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // Detect collision with other objects to control jump and game over
    private void OnCollisionEnter(Collision collision)
    {
        // Detect if player is on ground again (completed jump)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!gameOver) // Fixed bug the dirt keeps playing when obstacle is hit while jumping
            {
                dirtParticle.Play();
            }
        } else if (collision.gameObject.CompareTag("Obstacle")) // Detect if player has hit an obstacle
        {
            gameOver = true;
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
        }
    }
}
