using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 100f;
    public float speed = 3f;

    private Transform player;
    private Rigidbody zombieRigidbody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 movement = direction * speed * Time.deltaTime;
        zombieRigidbody.MovePosition(transform.position + movement);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death animations or effects here
        Destroy(gameObject);
    }
}
