using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [Header("Wwise Stuff")]
    [SerializeField] AK.Wwise.Event _endScreenEvent;
    [SerializeField] AK.Wwise.Event _resumeEvent;

    private void OnEnable()
    {
        _endScreenEvent.Post(gameObject);
    }

    private void OnDisable()
    {
        _resumeEvent.Post(gameObject);
    }
}
