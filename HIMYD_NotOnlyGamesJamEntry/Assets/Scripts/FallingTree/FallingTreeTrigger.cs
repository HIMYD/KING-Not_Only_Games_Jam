using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTreeTrigger : MonoBehaviour
{
    private Animator treeAnimator;
    private AudioSource treeAudioSource;
    private MoleController moleController;

    private void Start()
    {
        treeAnimator = transform.parent.GetComponentInChildren<Animator>();
        treeAudioSource = transform.parent.GetComponentInChildren<AudioSource>();
        moleController = FindObjectOfType<MoleController>();//Singleton
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            moleController.isInTree = true;
            moleController.currTree = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            moleController.isInTree = false;
            moleController.currTree = null;
        }
    }

    public void MakeTreeFall()
    {
        treeAudioSource.Play();
        treeAnimator.SetTrigger("Fall");
    }
}
