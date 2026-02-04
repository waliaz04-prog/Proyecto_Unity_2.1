using UnityEngine;

public class TrampaArea : MonoBehaviour
{
    [SerializeField] private string tagJugador = "Player";

    private FlechaMovimiento3D flecha;

    private void Start()
    {
        flecha = GetComponent<FlechaMovimiento3D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagJugador)) return;

        if (flecha != null && !flecha.estaVisible)
            return;

        VidasJugador vidas = other.GetComponent<VidasJugador>();
        if (vidas != null)
        {
            vidas.ActivarTrampa();
        }
    }
}
