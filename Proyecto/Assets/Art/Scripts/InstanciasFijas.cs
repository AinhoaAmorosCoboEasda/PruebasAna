using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciasFijas : MonoBehaviour
{

    public Transform[] puntos = new Transform [3];
    //public GameObject item;
    public GameObject[] items = new GameObject[2];

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float impulsoFuerza = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextFire)
        {
            
            GameObject item;
            nextFire = Time.time + fireRate;
            Transform pos;
            pos = puntos[Random.Range(0, puntos.Length)];
            item = items[Random.Range(0, items.Length)];
            Instantiate(item, pos.position, Random.rotation);
          

        }
        
    }
}
