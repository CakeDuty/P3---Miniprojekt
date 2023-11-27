using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Set default values if needed
    public float minHealth = 10f;
    public float maxHealth = 100f;

    private float health;
    public float Health => health;

    public float speed = 3f;

    private Transform player;
    private Rigidbody zombieRigidbody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieRigidbody = GetComponent<Rigidbody>();

        // Set random health within the specified range
        health = Random.Range(minHealth, maxHealth);
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

            ScoringSystemTMP.Instance.AddScore(Random.Range(50, 100));

        }
    }

    void Die()
    {
      
        Destroy(gameObject);
    }
}
