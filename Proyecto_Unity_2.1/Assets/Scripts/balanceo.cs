using UnityEngine;

public class Balanceo : MonoBehaviour
{
    [Header("Balanceo")]
    public float anguloMaximo = 45f; 
    public float velocidad = 2f;      

    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.localRotation;
    }

    void Update()
    {
        float angulo = Mathf.Sin(Time.time * velocidad) * anguloMaximo;
        transform.localRotation = rotacionInicial * Quaternion.Euler(0f, 0f, angulo);
    }
}
