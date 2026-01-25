using UnityEngine;
using System.Collections.Generic;

public class MovimientoCurvo : MonoBehaviour
{
    [Header("Puntos de la curva (mínimo 3)")]
    public List<Transform> puntos;

    [Header("Movimiento")]
    public float velocidad = 1f;
    public bool bucle = true;

    private float t = 0f;
    private int segmentoActual = 0;

    void Update()
    {
        if (puntos.Count < 3) return;

        t += Time.deltaTime * velocidad;

        if (t > 1f)
        {
            t = 0f;
            segmentoActual++;

            if (segmentoActual >= puntos.Count - 2)
            {
                if (bucle)
                    segmentoActual = 0;
                else
                    segmentoActual = puntos.Count - 3;
            }
        }

        Vector3 pos = CatmullRom(
            puntos[segmentoActual].position,
            puntos[segmentoActual + 1].position,
            puntos[segmentoActual + 2].position,
            puntos[segmentoActual + 3 >= puntos.Count ? (bucle ? 0 : puntos.Count - 1) : segmentoActual + 3].position,
            t
        );

        transform.position = pos;
    }

    Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return 0.5f * (
            (2f * p1) +
            (-p0 + p2) * t +
            (2f * p0 - 5f * p1 + 4f * p2 - p3) * t * t +
            (-p0 + 3f * p1 - 3f * p2 + p3) * t * t * t
        );
    }
}
