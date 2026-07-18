using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Singleton
    public static SoundManager Instance { get; private set; }

    //Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    //NotSingleton
    [Header("Player Events")]
    public AK.Wwise.Event playerFire;

    public void PlayerFire(GameObject gameObject)
    {
        playerFire?.Post(gameObject);
    }
}
