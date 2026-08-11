using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooter : MonoBehaviour
{
    public float shootInterval = 2f;
    public GameObject projectilePrefab;
    public GameObject shootPoint;
    public float projectileSpeed = 500f;

    [Header("SoundStuff")]
    [SerializeField] public AK.Wwise.Event shootAudio;

    private void Start()
    {
        StartCoroutine(shootCoro(shootInterval));
    }

    private IEnumerator shootCoro(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ShootProjectile();
        }    
    }

    void ShootProjectile()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.transform.position, Quaternion.Euler(direction));

            projectile.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;
        }
    }
}
