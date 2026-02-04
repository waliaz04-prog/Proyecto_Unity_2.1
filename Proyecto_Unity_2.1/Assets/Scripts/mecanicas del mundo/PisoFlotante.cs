using UnityEngine;

public class PisoFlotante : MonoBehaviour
{
    [Header("Flotación")]
    [SerializeField] private float bajada = 0.35f;      
    [SerializeField] private float suavidad = 0.25f;    
    [SerializeField] private float rebote = 0.15f;      

    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;
    private Vector3 velocidadActual;
    private bool jugadorEncima;

    void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            posicionObjetivo,
            ref velocidadActual,
            suavidad
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = true;
            posicionObjetivo = posicionInicial + Vector3.down * bajada;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = false;

            // Rebote flotante al soltar
            posicionObjetivo = posicionInicial + Vector3.up * rebote;
            Invoke(nameof(RegresarPosicion), 0.15f);
        }
    }

    void RegresarPosicion()
    {
        if (!jugadorEncima)
            posicionObjetivo = posicionInicial;
    }
}