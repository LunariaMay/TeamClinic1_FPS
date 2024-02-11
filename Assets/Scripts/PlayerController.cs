using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 2f;
    public Transform spawnPoint;

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        
        transform.Translate(movement);

        // Player rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed;
        transform.Rotate(rotation);

        // Optional: You might want to add jumping logic, shooting logic, etc. here.

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 10f;
        }
        else
        {
            movementSpeed = 5f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            gameObject.transform.position = spawnPoint.position;
        }
    }
}
