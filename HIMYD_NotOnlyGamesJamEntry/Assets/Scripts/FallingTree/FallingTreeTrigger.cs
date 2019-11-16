using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTreeTrigger : MonoBehaviour
{
    private Animator treeAnimator;
    private AudioSource treeAudioSource;

    private void Start()
    {
        treeAnimator = transform.parent.GetComponentInChildren<Animator>();
        treeAudioSource = transform.parent.GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            MoleController moleController = other.GetComponent<MoleController>();
            if (moleController.button_a.state == KEY_STATE.KEY_DOWN)
            {
                treeAudioSource.Play();
                treeAnimator.SetTrigger("Fall");
            }
        }
    }
}
