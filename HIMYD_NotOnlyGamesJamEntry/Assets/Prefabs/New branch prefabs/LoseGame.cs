using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    private float timer = 0f;
    private bool loseGame = false;
    public float delayRestartScene;
    private AudioSource loseSound;

    private void Start()
    {
        loseSound = GetComponent<AudioSource>();
    }

    public void LostGame()
    {
        if (!loseGame)
        {
            loseSound.Play();
            loseGame = true;
        }
    }

    void Update()
    {
        if (loseGame)
        {
            timer += Time.deltaTime;
            if (timer > delayRestartScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
