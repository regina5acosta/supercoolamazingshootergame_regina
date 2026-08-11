using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : Target
{
    //public GameObject enemyPaintballPrefab;

    //void FireEnemyPaintball()
    //{
    // GameObject ball = Instantiate(enemyPaintballPrefab, firePoint.position, firePoint.rotation);
    // IgnorePlayerCollision(ball);
    // Rigidbody rb = ball.GetComponent<Rigidbody>();
    // rb.linearVelocity = firePoint.forward * paintballSpeed;
    // }

    public float shootInterval = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public GameObject shootPoint;
    

    void Start()
    {
        StartCoroutine(shootCoro(shootInterval));
    }

    private IEnumerator shootCoro(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ShootProjectle();
            //SoundManager.Instance.EnemyShooterSound(gameObject);
        }
    }

    void ShootProjectle()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 direction = (player.transform.position - shootPoint.transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.transform.position, Quaternion.Euler(direction));
            projectile.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;

            //SoundManager.Instance.ProjectileSound(gameObject);

        }
    }


}
