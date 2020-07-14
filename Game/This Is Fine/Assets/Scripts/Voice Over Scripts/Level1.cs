using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public AudioClip line1;
    public AudioClip line2;

    private AudioSource source;

    private bool toldOff = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = line1;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !toldOff)
        {
            toldOff = true;
            source.Stop();
            source.clip = line2;
            source.Play();
        }
    }
}
