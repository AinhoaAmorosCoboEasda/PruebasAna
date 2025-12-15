using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erupcion : MonoBehaviour
{
    public GameObject item;
    public float fireRate = 5f;

    // Use this for initialization
    void Start()
    {
        // Invocar una corrutina
        StartCoroutine(LanzarItems());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LanzarItems()
    {
        // No llamar a la corrutina hasta pasados 2 segundos
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            Instantiate(item, transform.position, Random.rotation);
            

            // Cuando tiene Unity que invocar otra vez la corrutina y que no dependa del frame
            yield return new WaitForSeconds(fireRate);
        }
    }
}