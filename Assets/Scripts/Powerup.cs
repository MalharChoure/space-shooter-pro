using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _movespeed = 10f;
    [SerializeField]
    private int _powerUpId;
    [SerializeField]
    private AudioClip _powerUpSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0)*_movespeed*Time.deltaTime);
        if(transform.position.y<-9)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_powerUpSound, transform.position);
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                switch(_powerUpId)
                {
                    case 0:
                        player.Tripleshot();
                        break;

                    case 1:
                        player.Speedup();
                        break;

                    case 2:
                        player.ShieldUp();
                        break;

                    default:
                        Debug.Log("Should not be here");
                        break;

                }
                //Debug.Log("here");
                //if (_powerUpId == 0)
                //{
                //    player.Tripleshot();
                //}
                //else if (_powerUpId == 1)
                //{
                //    player.Speedup();
                //}
                //else
                //{
                //}
            }
            Destroy(this.gameObject);
        }
    }
}
