using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public ParticleSystem shootParticles;


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Zombie zombie = hit.collider.GetComponent<Zombie>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            if (shootParticles != null)
            {
                shootParticles.Play();
            }
        }
    }
}
