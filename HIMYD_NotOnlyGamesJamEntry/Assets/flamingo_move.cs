using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingo_move : MonoBehaviour
{
    public GameObject door;
    public float distance_to_move;
    private float final_pos = 0;
    public float speed;

    public float sound_time = 10.0f;

    private float sound_timer;

    // Start is called before the first frame update
    void Start()
    {
        final_pos = gameObject.transform.position.x + distance_to_move;
    }

    // Update is called once per frame
    void Update()
    {
        if (door.GetComponent<Door_manage>().buttons_pressed)
        {
            if (gameObject.transform.position.x < final_pos) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }

        sound_timer += Time.deltaTime;

        if(sound_timer >= sound_time)
        {
            sound_timer = 0;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
