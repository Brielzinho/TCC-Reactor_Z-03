using UnityEngine;

public class ScriptDaMascara : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pegando os dados do script "VidaDoJogador" e os acessando aqui
        VidaDoJogador jogador = other.GetComponent<VidaDoJogador>();
        
        // verificando se o jogador está sem a mascará e a equipando
        if (jogador != null)
        {
            jogador.EquiparMascara();
            Destroy(gameObject); // A máscara desaparece depois de pegar
        }
    }
}
