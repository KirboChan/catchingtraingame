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
        playerHealth.health--;
        getPlayer.anim.SetBool("isHit", true);
        if (playerHealth.health <= 0)
        {
            Destroy(getPlayer.gameObject);
        }
        yield return new WaitForSeconds(duration);
        getPlayer.anim.SetBool("isHit", false);
        getPlayer.moveSpeed = getPlayer.moveSpeedDefault;
        Destroy(this.gameObject);
    }
}
