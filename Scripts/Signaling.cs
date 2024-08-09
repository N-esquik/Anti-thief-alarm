using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private float _maxVolumeInside = 1f;
    private float _maxVolumeOutside = 0f;
    private float _speed = 10f;
    private float _time = 0.1f;

    private bool _isPlaying = true;

    public void IncreaseVolume()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountUpVolumeOfSound(_maxVolumeInside));
    }

    public void ReduceVolume()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountUpVolumeOfSound(_maxVolumeOutside));
    }

    private IEnumerator CountUpVolumeOfSound(float volume)
    {
        var wait = new WaitForSecondsRealtime(_time);

        while (_isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _speed * Time.deltaTime);
            yield return wait;
        }
    }
}
