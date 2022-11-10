using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;
    [SerializeField]
    private float _enemyX;
    [SerializeField]
    private float _enemyY=7.8f;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _lasercollidable;

    [SerializeField]
    private AudioClip _explosion_sound;
    private AudioSource _audioSource;

    private Animator _animator;

    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player= GameObject.Find("Player").GetComponent<Player>();
        //_enemyX=Random.Range(-9.4f,9.4f);
        //transform.position = new Vector3(_enemyX, _enemyY, 0);
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _explosion_sound;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * _enemySpeed * Time.deltaTime);
        if(transform.position.y < -8)
        {
            _enemyX = Random.Range(-11.5f, 11.5f);
            transform.position = new Vector3(_enemyX, _enemyY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player") 
        {
            _enemySpeed = 0;
            _animator.SetTrigger("OnEnemyDeath");
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _audioSource.Play();
            Destroy(this.gameObject,2.5f);
        }
        if(other.tag == "Laser")
        {
            _enemySpeed = 0;
            _animator.SetTrigger("OnEnemyDeath");
            if (_player!=null)
            {
                _player.addscore(10);
            }
            Destroy(other.gameObject);// getting error here
            _audioSource.Play();
            Destroy(this.gameObject,2.5f);
        }
    }
}
