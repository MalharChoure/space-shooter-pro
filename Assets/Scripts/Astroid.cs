using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    private float _astroidSpeed = 5;


    [SerializeField]
    private GameObject _explosion;

    private SpawnManager _Spawn_manager;

    // Start is called before the first frame update
    void Start()
    {
        _Spawn_manager=GameObject.Find("Spawn_manager").GetComponent<SpawnManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,_astroidSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _Spawn_manager.start_spawning();
            Instantiate(_explosion,transform.position, Quaternion.identity);
            Destroy(this.gameObject,0.25f);
        }

    }
}
