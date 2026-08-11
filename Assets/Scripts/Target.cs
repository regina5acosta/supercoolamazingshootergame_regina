using AK.Wwise;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 10;
    public float lifetime = 8f;

    [SerializeField] AK.Wwise.Event _targetHit;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void DestroyTarget()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
        _targetHit.Post(gameObject);
    }
}