using UnityEngine;

public class AreaDeRadiacao : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D other)
    {
        // Pegando os dados do script "VidaDoJogador" e os acessando aqui
        VidaDoJogador jogador = other.GetComponent<VidaDoJogador>();
        
        // verificando se o jogador está com a mascará e se não estiver usando, tomará dano
        if (jogador != null)
        {
            jogador.TomandoDano(10f); // Dano por segundo
        }
    }
}
