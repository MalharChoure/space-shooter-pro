using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,1,0)*_laserSpeed*Time.deltaTime);
        if(transform.position.y>8)
        {
            if(transform.parent!=null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);//alternatively i can use this.gameObject which return the game object this script is attached tos
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.transform.name=="enemy")
        //{
           // Destroy(this.gameObject);
        //}
    }
}
