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
    public AK.Wwise.Event weaponFireEvent;
    public AK.Wwise.Event targetHitEvent;
    public AK.Wwise.Event grenadeExplosionEvent;
    public AK.Wwise.Event collectiblePickupEvent;
    public AK.Wwise.Event paintballImpactEvent;
    public AK.Wwise.Event uiClickEvent;
    public AK.Wwise.Event targetSpawnEvent;
    public AK.Wwise.Event sniperHitEvent;
    public AK.Wwise.Event musicEvent;
    public AK.Wwise.Event ambienceEvent;

    public void PlayerFire(GameObject gameObject)
    {
        playerFire?.Post(gameObject);
    }
}
