using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erupcion : MonoBehaviour
{
    
    //public gameboject item:

    public GameObject[] items = new GameObject[2];
    public GameObject item;
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
            nextFire = Time.time + fireRate;

            // Elegimos un item aleatorio del array
            item = items[Random.Range(0, items.Length)];

            // Posición y rotación aleatorias
            item.transform.position = new Vector3(Random.Range(32f, 52f), -20f, Random.Range(-6f, -25f));
            item.transform.rotation = Random.rotation;

            // Creamos el nuevo objeto
            GameObject nuevoItem = Instantiate(item, item.transform.position, item.transform.rotation);

         
        }
    }
}