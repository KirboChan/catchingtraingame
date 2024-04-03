using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleHit1 : MonoBehaviour
{
    public float slowFactor;
    public float duration;
    public playerScript getPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SlowPlayer());
        }
    }
    IEnumerator SlowPlayer()
    {
        getPlayer.moveSpeed /= slowFactor;
        yield return new WaitForSeconds(duration);
        getPlayer.moveSpeed = getPlayer.moveSpeedDefault;
    }


}
