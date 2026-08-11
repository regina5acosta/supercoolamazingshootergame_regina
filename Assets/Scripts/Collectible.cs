using UnityEngine;

public class Collectible : MonoBehaviour
{
    public BulletType grantedBulletType;
    public float perkDuration = 10f;
    public float rotateSpeed = 90f;
    public float bobSpeed = 2f;
    public float bobHeight = 0.25f;

    Vector3 startPos;
    [Header("Wwise Events")]
    [SerializeField] AK.Wwise.Event _collectibleEvent;


    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 pos = startPos;
        pos.y += Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        WeaponSystem weapon = other.GetComponent<WeaponSystem>();
        if (weapon == null) weapon = other.GetComponentInParent<WeaponSystem>();

        if (weapon != null)
        {
            weapon.SetBulletType(grantedBulletType, perkDuration);
            Destroy(gameObject);
        }
        _collectibleEvent.Post(gameObject);
    }
}
