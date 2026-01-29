using System.Collections;
using UnityEngine;

public class FlechaMovimiento3D : MonoBehaviour
{
    public Transform punto1;
    public Transform punto2;

    public float velocidadMovimiento = 3f;
    public float velocidadFade = 1f;

    private Renderer rend;
    private Color colorOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;

        transform.position = punto1.position;
        StartCoroutine(Ciclo());
    }

    IEnumerator Ciclo()
    {
        while (true)
        {
            // IR AL PUNTO 2
            yield return StartCoroutine(Mover(punto2));

            // QUEDARSE Y DESAPARECER EN PUNTO 2
            yield return StartCoroutine(Fade(1f, 0f));

            // REGRESAR AL PUNTO 1 INVISIBLE
            yield return StartCoroutine(Mover(punto1));

            // VOLVER A APARECER EN PUNTO 1
            yield return StartCoroutine(Fade(0f, 1f));
        }
    }

    IEnumerator Mover(Transform destino)
    {
        while (Vector3.Distance(transform.position, destino.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino.position,
                velocidadMovimiento * Time.deltaTime
            );
            yield return null;
        }
    }

    IEnumerator Fade(float alphaInicio, float alphaFinal)
    {
        float t = 0f;
        Color c = colorOriginal;

        while (t < 1f)
        {
            t += Time.deltaTime * velocidadFade;
            c.a = Mathf.Lerp(alphaInicio, alphaFinal, t);
            rend.material.color = c;
            yield return null;
        }
    }
}
