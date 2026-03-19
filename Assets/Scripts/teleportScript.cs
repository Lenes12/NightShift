using UnityEngine;
using System.Collections;

public class teleportScript : MonoBehaviour
{
    public Transform destination;
    public teleportScript otherTeleporter;

    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null && destination != null)
            {
                var player = rb.GetComponent<PlayerScript>();

                if (player != null)
                    player.isTeleporting = true;

             
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

              
                rb.position = destination.position;

             
                if (otherTeleporter != null)
                    otherTeleporter.DisableTemporarily();

                StartCoroutine(ResetTeleport(player));
            }
        }
    }

    public void DisableTemporarily()
    {
        StartCoroutine(DisableRoutine());
    }

    private IEnumerator DisableRoutine()
    {
        isActive = false;
        yield return new WaitForSeconds(0.2f);
        isActive = true;
    }

    private IEnumerator ResetTeleport(PlayerScript player)
    {
        yield return null;

        if (player != null)
            player.isTeleporting = false;
    }
}


