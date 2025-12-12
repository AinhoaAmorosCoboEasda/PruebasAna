using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCapsula : MonoBehaviour
{
    public float velocidad = 1.0f;
    public float inputhorizontal;
    public float inpuvertical;
    public CharacterController Player2;

    private Vector3 Player2Input;

    public float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        Player2 = GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    { 
        Player2Input.x= Input.GetAxisRaw("Horizontal") * velocidad;
        Player2Input.z= Input.GetAxisRaw("Vertical") * velocidad;
        
        if (Input.GetButtonDown("Jump") && Player2.isGrounded) 
         Player2Input.y = 8.0f;
        
        Player2Input.y += gravity * Time.deltaTime;
        
        Player2.Move(Player2Input * Time.deltaTime);
        
    }
}
