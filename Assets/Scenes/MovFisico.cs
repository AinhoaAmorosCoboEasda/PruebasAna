using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFisico : MonoBehaviour
{
    public float jump;
    public float force;
    public LayerMask groundlayer;

    private bool isGrounded;
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")  && isGrounded)
        {
            rigid.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
       
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f, groundlayer);

       
        rigid.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * force);
    }

     public void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Cubos Rojos")
        {
            other.GetComponent<MeshRenderer> ().material.color = Color.blue;
        }

        if (other.tag == "Cubos Verdes")
        {
            Destroy(other);
        }
    }
    
}