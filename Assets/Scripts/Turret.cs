using UnityEngine;

public class Turret : Target
{
    public GameObject enemyPaintballPrefab;

    void FireEnemyPaintball()
    {
        GameObject ball = Instantiate(enemyPaintballPrefab, firePoint.position, firePoint.rotation);
        IgnorePlayerCollision(ball);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * paintballSpeed;
    }
    

}
