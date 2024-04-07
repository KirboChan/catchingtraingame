using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class busAnimation : MonoBehaviour
{
    audioManager thisAudioManager;
    public UnityEvent playBusAnimation;
    Animator animator;
    public GameObject spawnPlayer;
    public GameObject hud;

    private void Awake()
    {
        thisAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("busPlay", false);

        thisAudioManager.PlaySFX(thisAudioManager.busIdle);
    }

    public void PlayAnimation()
    {
        hud.SetActive(false);
        thisAudioManager.PlaySFX(thisAudioManager.busStart);
        animator.SetBool("busPlay", true);
        spawnPlayer.SetActive(true);
    }
    
    public void AnimationComplete()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
