using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public AudioClip line1;
    public AudioClip line2;

    private bool speedBoost = false;
    private bool speedSlow = false;

    private AudioSource source;

    private float audioStartTime;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = line1;
        source.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !speedBoost)
        {
            speedBoost = true;
            Modifiers.MoveSpeed = 100f;
            audioStartTime = Time.time;
            source.Stop();
            source.clip = line2;
            source.Play();
            Modifiers.MusicPitch += .4f;
        }

        if(Time.time > audioStartTime + 9f && !speedSlow && speedBoost)
        {
            speedSlow = true;
            Modifiers.MoveSpeed = 20f;
            Modifiers.MusicPitch -= .2f;
        }
    }
}
