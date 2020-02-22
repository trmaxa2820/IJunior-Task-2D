using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private float _spawnTime;
    [SerializeField] private ParticleSystem _partical;
    
    private AudioSource _audioSource;
    private float _timeToSpawn;
    private int _spawnedCoin = 0;

    private void Start()
    {
        _timeToSpawn = _spawnTime;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_timeToSpawn >= 0)
            _timeToSpawn -= Time.deltaTime;

        if (_spawnedCoin == 0 && _timeToSpawn <= 0)
        {
            _spawnedCoin++;
            Instantiate(_coin, transform.position, Quaternion.identity);
            _timeToSpawn = _spawnTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            if(_spawnedCoin == 1)
            {
                StartAction();
            }

            ChangeValueSpawnedCoin();
        }
    }

    public void ChangeValueSpawnedCoin()
    {
        _spawnedCoin = 0;
    }

    public void StartAction()
    {
        _partical.Play();
        _audioSource.Play();
    }
}
