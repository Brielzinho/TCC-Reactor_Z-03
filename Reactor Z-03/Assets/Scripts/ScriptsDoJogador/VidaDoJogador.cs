using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    public float vida = 100f;
    public bool estaComMascara = false; // Começa sem a máscara

    // Método para retirar a vida do jogador quando está sem a máscara
    public void TomandoDano(float valor)
    {
        if (!estaComMascara)
        {
            vida -= valor * Time.deltaTime;
            Debug.Log("Tomando dano! Vida: " + vida);
        }
    }

    // Método para equipar a máscara
    public void EquiparMascara()
    {
        estaComMascara = true;
        Debug.Log("Máscara equipada!");
    }
}
