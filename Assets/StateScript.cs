using UnityEngine;

public class StateScript : MonoBehaviour
{
    [SerializeField] AK.Wwise.State _enableState;
    [SerializeField] AK.Wwise.Event _enableEvent;
    
    [SerializeField] AK.Wwise.State _disableState;
    [SerializeField] AK.Wwise.Event _disableEvent;

    private void OnEnable()
    {
        _enableState.SetValue();
        _enableEvent.Post(gameObject);
    }

    private void OnDisable()
    {
        _disableEvent.Post(gameObject);
        _disableState.SetValue();
    }
}
