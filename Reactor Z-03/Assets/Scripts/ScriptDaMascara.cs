using UnityEngine;

public class ScriptDaMascara : MonoBehaviour
{
    private bool jogadorNaArea = false;
    private VidaDoJogador jogador;
        
    void Update()
    {
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.E))
        {
            if (!jogador.estaComMascara)
            {
                jogador.EquiparMascara();
                UIInteracao.instancia.EsconderMensagem();
                Destroy(gameObject); // Máscara desaparece após equipar
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        jogador = other.GetComponent<VidaDoJogador>();
        if (jogador != null)
        {
            jogadorNaArea = true;
            UIInteracao.instancia.MostrarMensagem("Aperte E para equipar máscara");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<VidaDoJogador>() != null)
        {
            jogadorNaArea = false;
            jogador = null;
            UIInteracao.instancia.EsconderMensagem();
        }
    }
}