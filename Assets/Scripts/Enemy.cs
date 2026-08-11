using System;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour//, IDamageable
{
    public bool destroyOnCollision = false;
    public int damageToPlayer = 10;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(collision);
        }
        if (collision.gameObject.CompareTag("Turret"))
        {
            DealDamageToPlayer(collision);
        }
    }

    private void DealDamageToPlayer(Collider collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damageToPlayer);
        }

        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }
}