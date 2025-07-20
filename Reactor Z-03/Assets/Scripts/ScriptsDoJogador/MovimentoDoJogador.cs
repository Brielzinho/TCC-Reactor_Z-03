using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;

public class MovimentoDoJogador : MonoBehaviour
{
    // Criando as Variáveis para o jogador
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDist;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;

    private bool canJump;
    private bool isGroundCheck;
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpForce;
    private bool isDirectionRight = true;
    private float inputDirection;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DirectionCheck();
        GetInputMove();
        CanJump();
        MoveAnim();
        JumpAnim();
    }	

    /* Criando o método "FixedUpdate" para que a Unity possa rodar o método do movimento do jogador, não pode ser colocado no "Update", 
    pois esse método não trabalha com o RigidBody nele. */

    void FixedUpdate()
    {
        MoveLogic();
        checkArea();
    }

    void CanJump()
    {
        if (isGroundCheck && rb2d.linearVelocity.y <= 0)
        {
            canJump = true;
        }
        else 
        {
            canJump = false;
        }
    }

    void checkArea()
    {
        isGroundCheck = Physics2D.OverlapCircle(groundCheck.position, groundDist, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDist);
    }

    void DirectionCheck()
    {
        if(isDirectionRight && inputDirection < 0)
        {
            Flip();
        }
        else if(!isDirectionRight && inputDirection > 0)
        {
            Flip();
        }
    }

    void GetInputMove()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }	

    void JumpAnim()
    {
        anim.SetFloat("VerticalAnim", rb2d.linearVelocity.y);
        anim.SetBool("groundCheck", isGroundCheck);
    }

    // Criando o método para que o jogador possa se movimentar
    public void MoveLogic()
    { 
        rb2d.linearVelocity = new Vector2(inputDirection * movespeed, rb2d.linearVelocity.y); 

    }

    void MoveAnim()
    {
        anim.SetFloat("HorizontalAnim", rb2d.linearVelocity.x); 

    }

    void Jump()
    {
        if (canJump)
        {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);            
        }
    }

    void Flip()
    {
        isDirectionRight = !isDirectionRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
