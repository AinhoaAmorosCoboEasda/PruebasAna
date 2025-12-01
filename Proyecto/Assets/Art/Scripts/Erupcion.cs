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
        GetComponent<Rigidbody>().AddForce(Vector3.up * impulsoFuerza, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject item;
        if (Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            item = items[Random.Range(0, items.Length)];
            item.transform.position = new Vector3 (Random.Range(32f, 52f), -20f, Random.Range(-6f, -25f));
            item.transform.rotation = Random.rotation;
            Instantiate(item, item.transform.position, item.transform.rotation);

        }
        
    }
}
