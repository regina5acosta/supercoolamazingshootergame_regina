using UnityEngine;

public class JaneRemover : MonoBehaviour
{
    [Header ("Wwise Stuff")]
    [SerializeField]AK.Wwise.Event _janeRemover;
    public Collider janeRemover;



    private void OnTriggerEnter(Collider collider)
    {
        _janeRemover.Post(gameObject);
    }
    
    //private void Start()
    //{
      //  OnTriggerColliderEnter();
    //}

}
