using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource speaker;

    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float newPitch = Modifiers.MusicPitch;
        if(Modifiers.MoveSpeed != 5f)
        {
            newPitch += .1f;
        }

        speaker.pitch = newPitch;
    }
}
