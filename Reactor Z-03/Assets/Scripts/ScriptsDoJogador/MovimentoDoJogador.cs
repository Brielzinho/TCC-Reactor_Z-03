using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimentoDoJogador : MonoBehaviour
{
    // Criando as Variáveis para o jogador
    public float velocidadeDoJogador;
    public Rigidbody2D oRigidbody2D;


    /* Criando o método "FixedUpdate" para que a Unity possa rodar o método do movimento do jogador, não pode ser colocado no "Update", 
    pois esse método não trabalha com o RigidBody nele. */ 
    
    void FixedUpdate()
    {
        MovimentarJogador();
    }

    // Criando o método para que o jogador possa se movimentar
    public void MovimentarJogador()
    { 
        float inputDoMovimento = Input.GetAxisRaw("Horizontal");
        oRigidbody2D.linearVelocity = new Vector2(inputDoMovimento * velocidadeDoJogador, oRigidbody2D.linearVelocity.y); 

    }
}
