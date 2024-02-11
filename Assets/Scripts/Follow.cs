using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent Target;

    [SerializeField] private float timer = 5f;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform SpawnPoint;
    public Transform EPoint;
    public float enemySpeed;
    public float playerSpeed;
    public float bulletLifetime = 2.0f; // Adjust the lifetime as needed

    void Start()
    {
        // Initialize the NavMeshAgent
        Target = GetComponent<NavMeshAgent>();

        // Check if the NavMeshAgent is properly initialized
        if (Target == null)
        {
            Debug.LogError("NavMeshAgent is not properly initialized!");
        }
    }

    void Update()
    {
        if (Player != null)
        {
            // Calculate the direction from AI to player
            Vector3 direction = Player.position - transform.position;

            // Normalize the direction to have a magnitude of 1
            direction.Normalize();

            // Move the AI towards the player
            transform.Translate(direction * playerSpeed * Time.deltaTime);
        }
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);

        // Destroy the bullet after a certain amount of time
        Destroy(bulletObj, bulletLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            gameObject.transform.position = EPoint.position;
        }
    }
}
