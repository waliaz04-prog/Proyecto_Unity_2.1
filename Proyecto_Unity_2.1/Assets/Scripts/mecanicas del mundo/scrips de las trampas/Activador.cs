using UnityEngine;

public class Activador : MonoBehaviour
{
    [SerializeField] private string tagJugador = "Player";
    [SerializeField] private FlechaMovimiento3D flecha;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            if (flecha != null)
            {
                flecha.Activar();
            }
        }
    }
}
