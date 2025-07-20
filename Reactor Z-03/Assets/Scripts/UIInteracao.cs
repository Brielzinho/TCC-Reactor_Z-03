using TMPro;
using UnityEngine;

public class UIInteracao : MonoBehaviour
{
    public static UIInteracao instancia;

    [SerializeField] private TextMeshProUGUI textoInteracao;

    void Awake()
    {
        instancia = this;
        textoInteracao.gameObject.SetActive(false);
    }

    public void MostrarMensagem(string mensagem)
    {
        textoInteracao.text = mensagem;
        textoInteracao.gameObject.SetActive(true);
    }

    public void EsconderMensagem()
    {
        textoInteracao.gameObject.SetActive(false);
    }
}
