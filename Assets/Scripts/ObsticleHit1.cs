using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleHit1 : MonoBehaviour
{
    public float slowFactor;
    public float duration;
    public playerScript getPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (getPlayer != null)
            {
                StartCoroutine(SlowPlayer(getPlayer));
            }
        }
    }

    IEnumerator SlowPlayer(playerScript thisPlayer)
    {
        getPlayer.moveSpeed = Mathf.Max(getPlayer.moveSpeed - slowFactor, 0f);
        yield return new WaitForSeconds(duration);
        getPlayer.moveSpeed /= slowFactor; 
    }
}
