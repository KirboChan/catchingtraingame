using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && playerScript.gameActive == true)
        {
            playerScript.gameActive = false;
        }
    }
}
