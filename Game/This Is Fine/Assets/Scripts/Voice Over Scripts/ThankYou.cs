using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankYou : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThankYouMessage());
    }

    private IEnumerator ThankYouMessage()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(9.5f);
        SceneManagement.ReturnToMain();
    }
}
