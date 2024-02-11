using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public Rigidbody bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Instantiate the bullet
            Rigidbody clone = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Get the player's forward direction
            Vector3 playerForward = transform.forward;

            // Set the bullet's velocity to move in the player's forward direction
            clone.velocity = playerForward * speed;
        }
    }
}
