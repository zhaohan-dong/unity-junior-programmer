using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; // Speed
    public float xRange = 10.0f; // Horizontal range for player
    public GameObject projectilePrefab; // Projectile food object

    private float horizontalInput; // Variable to load keyboard left-right input

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player position is within bound
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Get input and move player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Check if space is pressed and launch food from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + Vector3.up, projectilePrefab.transform.rotation);
        }
    }
}
