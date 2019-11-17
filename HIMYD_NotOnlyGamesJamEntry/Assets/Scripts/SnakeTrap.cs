using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrap : MonoBehaviour
{
    private AudioSource trapSFX;
    private Transform moleTransform;

    private void Start()
    {
        moleTransform = FindObjectOfType<MoleController>().transform;
        trapSFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if ((int)transform.position.x ==  (int)moleTransform.position.x
            && (int)transform.position.z == (int)moleTransform.position.z
            && (int)transform.position.y > (int)moleTransform.position.y)
        {
            if (!trapSFX.isPlaying)
            {
                //trapSFX.volume = 1f;
                trapSFX.Play();
            }
        }
        else
        {
            if (trapSFX.isPlaying)
            {
                //StartCoroutine(StartFade(trapSFX, 0.1f, 0f));
                trapSFX.Stop();
            }
        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
