using UnityEngine;

public class teletransportador : MonoBehaviour, IInteractable
{
    [Header("Destino")]
    [SerializeField] private Transform cristalDestino;

    [Header("Jugador")]
    [SerializeField] private PlayerMove jugador;
    [SerializeField] private float alturaOffset = 1f;

    public void Interact()
    {
        if (cristalDestino == null || jugador == null)
        {
            Debug.LogWarning("Teletransportador: falta asignar referencias");
            return;
        }

        CharacterController cc = jugador.GetComponent<CharacterController>();

        // Desactivar controller para evitar bugs
        cc.enabled = false;

        jugador.transform.position = cristalDestino.position + Vector3.up * alturaOffset;

        // Reactivar
        cc.enabled = true;
    }
}
