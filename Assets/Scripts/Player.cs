using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes Here we are using them to access variables that are declared private

    // use underscore for private variables as they are easier to identify later on
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserprefab;
    [SerializeField]
    private float _bulletOffset = 0.8f;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private int _health = 5;
    private float _canfire = -1;
    private SpawnManager _spawnmanager;
    [SerializeField]
    private GameObject _tripleshotprefab;
    [SerializeField]
    private bool _isTripleShotActive = false;
    private float _toffsetx = -1.785f;
    private float _toffsety = -0.42f;
    private bool _isShieldup = false;
    [SerializeField]
    private int _score;
    [SerializeField]
    private GameObject _shieldVisualizer;

    private UIManager _uimanager;
    [SerializeField]
    private AudioClip _laser_sound_clip;
    private AudioSource _audiosource;


    [SerializeField]
    private GameObject _rightEngine, _leftEngine;

    //public float horizintalInput;
    // Start is called before the first frame update
    void Start()
    {

        // take the current position and give it a start position
        // current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        _spawnmanager = GameObject.Find("Spawn_manager").GetComponent<SpawnManager>();
        if (_spawnmanager == null)
        {
            Debug.Log("Spawn Manager is null");
        }
        _shieldVisualizer.SetActive(false);
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uimanager==null)
        {
            Debug.Log("UImanger not found");
        }
        _leftEngine.SetActive(false);
        _rightEngine.SetActive(false);
        _audiosource = GetComponent<AudioSource>();
        if(_audiosource==null)
        {
            Debug.Log("Audio source is null");
        }
        else
        {
            _audiosource.clip = _laser_sound_clip;
        }

    }

    // Update is called once per frame
    void Update()
    {
        player_movement();
        laser_create();
        if(_isShieldup)
        {
           
        }
    }
    void player_movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x, Mathf.Min(0f, transform.position.y), 0);
        transform.position = new Vector3(transform.position.x, Mathf.Max(-5f, transform.position.y), 0);

        if (transform.position.x >= 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
    }

    void laser_create()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canfire)
        {
            if  (_isTripleShotActive == false)
            {
                _canfire = Time.time + _fireRate;
                Instantiate(_laserprefab, new Vector3(transform.position.x, transform.position.y + _bulletOffset, 0), Quaternion.identity);
            }
            if(_isTripleShotActive)
            {
                _canfire = Time.time + _fireRate;
                Instantiate(_tripleshotprefab, new Vector3(transform.position.x+ _toffsetx, transform.position.y+_toffsety, 0), Quaternion.identity);
            }
            _audiosource.Play();
        }
        //if (Input.GetKey(KeyCode.Space))
       // {
            //_time = Time.deltaTime + _time;
            //if (_time > _fireRate)
            //{//quaternian identity means default rotation and we use transform postition for getting the bullet to shoot from the centre of the object
                 //Instantiate(_laserprefab, new Vector3(transform.position.x, transform.position.y + _bulletOffset, 0), Quaternion.identity);
               // _time = 0f;
            //}
        //}
    }


    public void Damage()
    {
        if(_isShieldup)
        {
            _isShieldup = false;
            _shieldVisualizer.SetActive(false);
            return;
        }
        _health -= 1;
        if(_health==2)
        {
            _leftEngine.SetActive(true);
        }
        if(_health==1)
        {
            _rightEngine.SetActive(true);
        }
        _uimanager.playercurrentLife(_health);
        if(_health==0)
        {
            if(_spawnmanager!=null && _uimanager!=null)
            {
                _spawnmanager.OnPlayerDeath();
                _uimanager.game_end();
            }
            Destroy(this.gameObject);
        }
    }

    public void Tripleshot()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotDeactivate());
    }

    IEnumerator TripleShotDeactivate()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;
    }

    public void Speedup()
    {
        Debug.Log("i Am being called");
        _speed = 6.5f;
        StartCoroutine(SpeedupDeactivate());
    }

    IEnumerator SpeedupDeactivate()
    {
        yield return new WaitForSeconds(5f);
        _speed = 3.5f;

    }

    public void ShieldUp()
    {
        _isShieldup = true;
        _shieldVisualizer.SetActive(true);
    }

    public void addscore(int points)
    {
        _score = _score + points;
        _uimanager.addPlayerScore(_score);
    }
}
