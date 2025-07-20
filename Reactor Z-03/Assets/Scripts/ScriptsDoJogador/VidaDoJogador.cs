using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    public float vida = 100f;
    public bool estaComMascara = false; // Começa sem a máscara

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Método para retirar a vida do jogador quando está sem a máscara
    public void TomandoDano(float valor)
    {
        if (!estaComMascara)
        {
            vida -= valor * Time.deltaTime;
            Debug.Log("Tomando dano! Vida: " + vida);

            if (vida <= 0)
            {
                Morrer();
            }
        }
    }

    // Método para equipar a máscara
    public void EquiparMascara()
    {
        estaComMascara = true;
        if (anim != null)
        {
            anim.SetBool("comMascara",true);
        }	
        Debug.Log("Máscara equipada!");
    }

    private void Morrer()
    {
        Debug.Log("Jogador morreu!");
        Destroy(gameObject);
    }
}
