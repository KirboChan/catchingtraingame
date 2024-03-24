using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleHit2 : MonoBehaviour
{
    public float duration;
    public playerScript getPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StopPlayer());
        }
    }
    IEnumerator StopPlayer()
    {
        getPlayer.moveSpeed = 0;
        yield return new WaitForSeconds(duration);
        getPlayer.moveSpeed = getPlayer.moveSpeedDefault;
        Destroy(this.gameObject);
    }
}
