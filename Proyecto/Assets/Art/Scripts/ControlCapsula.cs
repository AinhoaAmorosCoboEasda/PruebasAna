using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ControlCapsula : MonoBehaviour
{
    public float velocidad = 1.0f;
    public float inputhorizontal;
    public float inpuvertical;
    public CharacterController Player2;
    private Vector3 movePlayer2 = Vector3.zero;

    private Vector3 Player2Input = Vector3.zero;
    
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    

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

        
        //esto es para homogeneizar los movimientos, si no se suman el x y el y, y en diagonal va mas rápido.
        movePlayer2 = Vector3.ClampMagnitude(movePlayer2, 1.0f);
        
        Player2.Move(Player2Input * Time.deltaTime);
        
        //para ver donde mira la camara
        camDirection();

        movePlayer2 = Player2Input.x * camRight + Player2Input.z * camForward;
        Player2.transform.LookAt(Player2.transform.position + movePlayer2);
        
        movePlayer2 = movePlayer2 * velocidad;

    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        //valores normalizados de 0 a 1
        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
}
