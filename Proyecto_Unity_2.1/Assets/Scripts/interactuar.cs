using UnityEngine;
using UnityEngine.InputSystem;

public class interactuar : MonoBehaviour
{
    public LayerMask interactuableLayers;

    [Header("Sonidos")]
    [SerializeField] private string sonidoInteractuar;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 20, out RaycastHit hit, 30, interactuableLayers))
        {
            Debug.Log(hit.collider);
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Interactuando");
                if (!string.IsNullOrEmpty(sonidoInteractuar))
                    AudioManager.Instance.Play(sonidoInteractuar);

                hit.collider.GetComponent<IInteractable>()?.Interact();
                Debug.Log("interactuando");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray.origin, ray.direction);
    }
}
