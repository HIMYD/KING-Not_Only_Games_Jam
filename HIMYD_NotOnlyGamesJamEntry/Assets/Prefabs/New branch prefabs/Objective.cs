using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    private List<Transform> characters;
    bool finishedLevel = false;
    public float timeToFinish;
    private float timer  = 0f;
    private AudioSource audioSource;

    private void Start()
    {
        characters = new List<Transform>();

        audioSource = GetComponent<AudioSource>();
        SimplestMovementController[] list = FindObjectsOfType<SimplestMovementController>();
        foreach (SimplestMovementController character in list)
        {
            characters.Add(character.transform);
        }
    }

    private void Update()
    {
        int count = 0;
        foreach (Transform character in characters)
        {
            if ((int)character.position.x == (int)transform.position.x
                && (int) character.position.z == (int)transform.position.z)
            {

                count++;
            }
        }

        if (count == 2)
        {
            if (!finishedLevel)
            {
                audioSource.Play();
                finishedLevel = true;
            }
        }

        if (finishedLevel)
        {
            timer += Time.deltaTime;
            if (timer > timeToFinish)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
