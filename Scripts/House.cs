using UnityEngine;

[RequireComponent(typeof(Signaling))]

public class House : MonoBehaviour
{
    private Signaling _signaling;

    private void Awake()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() == false)
            return;
        
        _signaling.IncreaseVolume();
    }

    private void OnTriggerExit(Collider other)
    {
        _signaling.ReduceVolume();
    }
}
