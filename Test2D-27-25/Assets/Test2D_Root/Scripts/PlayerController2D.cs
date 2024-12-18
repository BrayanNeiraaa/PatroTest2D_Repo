using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //libreria necesaria para leer el input system

public class PlayerController2D : MonoBehaviour
{
    //Referencias privadas generales
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveInput; //variable para referenciar el imput controladores

    [Header("Movement Parameters")]
    public float speed;
    [SerializeField] bool isFacingRight;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] GameObject groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer; 




    // Start is called before the first frame update
    void Start()
    {
        //Para autoferenciar: nombre de variable es = GetComponent<tipo de variable>()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
    }


    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    void GroundCheck()
    {
        //is grounded es verdadero cuando es circulo detector toque la layer ground 
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
    }
    #region Input Methods
    //Metodos que permiten leer el input del New Imput System
    //crearemos un metodo por cada accion

    public void HandleMovement(InputAction.CallbackContext context)
    {
        //las acciones de tipo VALUE deben almacenarse = Read/Value
        moveInput = context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)

            if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }
    #endregion




}
