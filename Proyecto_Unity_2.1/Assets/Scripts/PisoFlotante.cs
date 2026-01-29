using UnityEngine;

public class PisoFlotante : MonoBehaviour
{
    [Header("Flotación")]
    [SerializeField] private float bajada = 0.3f;      // Cuánto baja al pisarlo
    [SerializeField] private float velocidad = 2f;     // Velocidad del movimiento

    private Vector3 posicionInicial;
    private Vector3 posicionPisado;
    private bool jugadorEncima;

    void Start()
    {
        posicionInicial = transform.position;
        posicionPisado = posicionInicial + Vector3.down * bajada;
    }

    void Update()
    {
        Vector3 destino = jugadorEncima ? posicionPisado : posicionInicial;

        transform.position = Vector3.Lerp(
            transform.position,
            destino,
            Time.deltaTime * velocidad
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = false;
        }
    }
}
