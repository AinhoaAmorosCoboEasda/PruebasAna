using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFisico : MonoBehaviour
{
     public float speed = 10f;     // Fuerza de empuje de la esfera
        public float jumpForce = 5f;  // Fuerza de salto
        public LayerMask groundLayer; // Capa del suelo para detección de contacto
    
        private Rigidbody rb;
        private bool isGrounded;

        void OnCollisionEnter(Collision collision)
        {
            GameObject other = collision.gameObject;
            if (other.tag == "Suelo")
            {
                other.GetComponent<MeshRenderer>().material.color = Color.red;
            }    
            
        }
        
        void Start()
        {
            // Obtener el Rigidbody de la esfera
            rb = GetComponent<Rigidbody>();
            
            // Asegurarse de que no está en modo cinemático
            rb.isKinematic = false;
        }
    
        void Update()
        {
            // Movimiento horizontal
            float moveHorizontal = Input.GetAxis("Horizontal"); // A-D
            float moveVertical   = Input.GetAxis("Vertical");   // W-S

            Vector3 force = new Vector3(moveVertical, 0, moveHorizontal) * speed;
            rb.AddForce(force);
    
            // Saltar al presionar la tecla espacio
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    
        void FixedUpdate()
        {
            // Detección de si está en el suelo usando un raycast
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
        }
    }
