using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingo_sound : MonoBehaviour
{
    
    private float sound_time = 5.0f;
    private float sound_timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        sound_timer += Time.deltaTime;

        if(sound_timer >= sound_time)
        {
            sound_timer = 0.0f;
            gameObject.GetComponent<AudioSource>().Play();
        }

    }
}
