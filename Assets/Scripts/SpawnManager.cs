using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemy_container;
    [SerializeField]
    private GameObject[] _powerup;
    [SerializeField]
    private GameObject _powerupspeed;
    [SerializeField]
    private GameObject _powerupsheild;
    private bool _stopSpawning = false;
    // Start is called before the first frame update

    
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_spawning()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    
    //spawn game object every 5 seconds
    //create a coroutine of type IEnummerator -- Yeild Events
    //while loop
    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning==false)
        {
            GameObject newEnemy=Instantiate(_enemy,new Vector3(Random.Range(-9.5f, 9.5f),7.8f,0),Quaternion.identity);
            newEnemy.transform.parent = _enemy_container.transform;
            yield return new WaitForSeconds(2.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning==false)
        {
            int rand = Random.Range(0, 3);
            Debug.Log(rand);
            Instantiate(_powerup[rand], new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            //switch(rand)
            //{
            // case 0:

            // break;

            //  case 1:
            // Instantiate(_powerup[1], new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            // break;

            // case 2:
            //Instantiate(_powerup[2], new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            //  break;

            //default:
            //Debug.Log("Should not be here");
            //  break;
            //}//
            //if (rand == 0)
            //{
            //    Instantiate(_powerup, new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            //}
            //else if(rand==1)
            //{
            //    Instantiate(_powerupspeed, new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            //}
            //else
            //{
            //    //Instantiate(_powerup, new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0), Quaternion.identity);
            //}

            yield return new WaitForSeconds(Random.Range(3f,7f));
        }
    }
}
