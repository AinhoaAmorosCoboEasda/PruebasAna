using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class Impulso : MonoBehaviour
{

    public float impulsofuerza = 1f;
    public float maxTime = 3.0f;
    public float currentTime = 0.0f;

    //public GameObject explosion;
    //public GameObject itemExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * impulsofuerza * 10, ForceMode.Impulse);
        //itemExplosion.GetComponent<Rigidbody>().AddForce(Vector3.up * impulsofuerza * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        //Debug.Log("TiempoActual: "+ currentTime);
        if (currentTime >= maxTime)
            Destroy(gameObject);
        
    } 
    
        void OnMouseDown()
    {
       //Destroy (Instantiate (explosion,transform.position, quaternion.identity), 3.30f);
      // Destroy (Instantiate(itemExplosion,transform.position, quaternion.identity), 3.30f);
       Destroy (gameObject);
    }
}
