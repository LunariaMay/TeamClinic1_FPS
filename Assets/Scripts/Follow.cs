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
        // Check if the Target is not null before setting the destination
        if (Target != null)
        {
            Target.destination = Player.position;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            gameObject.transform.position = EPoint.position;
        }
    }
}
