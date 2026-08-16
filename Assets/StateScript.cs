using UnityEngine;

public class StateScript : MonoBehaviour
{
    [SerializeField] AK.Wwise.State _enableState;
    [SerializeField] AK.Wwise.Event _enableEvent;
    
   

    private void OnEnable()
    {
        _enableState.SetValue();
        _enableEvent.Post(gameObject);
    }

    
}
