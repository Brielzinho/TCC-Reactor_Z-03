using UnityEngine;

public class ScriptLanterna : MonoBehaviour
{
    public GameObject luzLanterna;  // Arraste o objeto com Light2D do tipo Spot aqui
    private bool temLanterna = false;
    private bool jogadorNaArea = false;

    private void Update()
    {
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.E) && !temLanterna)
        {
            PegarLanterna();
            UIInteracao.instancia.EsconderMensagem();
        }

        // Se já tem a lanterna, liga/desliga com tecla F
        if (temLanterna && Input.GetKeyDown(KeyCode.F))
        {
            luzLanterna.SetActive(!luzLanterna.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = true;
            UIInteracao.instancia.MostrarMensagem("Aperte E para equipar Lanterna");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = false;
            UIInteracao.instancia.EsconderMensagem();
        }
    }

    void PegarLanterna()
    {
        temLanterna = true;
        luzLanterna.SetActive(true); // Liga ao pegar, opcional
        Debug.Log("Lanterna equipada! Pressione F para ligar/desligar.");

        Destroy(gameObject); // Destrói o objeto da lanterna no chão
    }
}
