using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidasJugador : MonoBehaviour
{
    [Header("Vidas")]
    [SerializeField] private int vidasMaximas = 3;
    private int vidasActuales;

    [Header("UI")]
    [SerializeField] private Text textoVidas;

    [Header("Respawn (Teletransporte)")]
    [SerializeField] private Transform spawnPlayer;
    [SerializeField] private float alturaOffset = 1f;

    private PlayerMove jugador;
    private CharacterController cc;

    private void Start()
    {
        vidasActuales = vidasMaximas;

        jugador = GetComponent<PlayerMove>();
        cc = GetComponent<CharacterController>();

        ActualizarUI();
    }

    // Llamado por TrampaArea
    public void ActivarTrampa()
    {
        TeletransportarJugador();
        QuitarVida();
    }

    private void TeletransportarJugador()
    {
        if (spawnPlayer == null || jugador == null || cc == null)
        {
            Debug.LogWarning("VidasJugador: faltan referencias para el teletransporte");
            return;
        }

        // Desactivar CharacterController para evitar bugs
        cc.enabled = false;

        jugador.transform.position = spawnPlayer.position + Vector3.up * alturaOffset;

        // Reactivar
        cc.enabled = true;
    }

    private void QuitarVida()
    {
        vidasActuales--;

        if (vidasActuales <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ActualizarUI();
        }
    }

    private void ActualizarUI()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidasActuales;
        }
    }
}
