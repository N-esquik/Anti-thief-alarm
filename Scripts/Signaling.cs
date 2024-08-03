using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolumeInside = 1f;
    private float _minVolumeOutside = 0f;
    private float _duration = 8f;
    private float _volumeIncrement;
    private float _targetVolume;

    private void Start()
    {
        _audioSource.Play();
        _targetVolume = _audioSource.volume;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeIncrement * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() == false)
            return;

        SetTargetVolume(_maxVolumeInside);
    }

    private void OnTriggerExit(Collider other)
    {
        SetTargetVolume(_minVolumeOutside);
    }

    private void SetTargetVolume(float newTargetVolume)
    {
        _targetVolume = newTargetVolume;
        _volumeIncrement = Mathf.Abs(_targetVolume - _audioSource.volume) / _duration;
    }
}
