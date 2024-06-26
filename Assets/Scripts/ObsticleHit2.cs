using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleHit2 : MonoBehaviour
{
    public float duration;
    public playerScript getPlayer;
    private audioManager thisAudioManager;
    cameraFollow thiscamera;

    private void Awake()
    {
        thisAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
        thiscamera = GameObject.FindWithTag("MainCamera").GetComponent<cameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StopPlayer());
        }
    }
    IEnumerator StopPlayer()
    {
        if (playerHealth.health <= 0)
        {
            Destroy(getPlayer.gameObject);
            playerScript.playerAlive = false;
        }
        else
        {
            if (playerHealth.isInvisible == false )
            {
                StartCoroutine(playerHealth.instance.InvincibilityFrames());
                thisAudioManager.PlaySFX(thisAudioManager.charHit);
                getPlayer.moveSpeed = 0;
                playerHealth.health--;
                getPlayer.anim.SetBool("isHit", true);
                cameraShake.instance.Shake(0.35f, 0.1f);
            }
           
        }
        yield return new WaitForSeconds(duration);
        getPlayer.anim.SetBool("isHit", false);
        getPlayer.moveSpeed = getPlayer.moveSpeedDefault;
        Destroy(this.gameObject);
    }
}
