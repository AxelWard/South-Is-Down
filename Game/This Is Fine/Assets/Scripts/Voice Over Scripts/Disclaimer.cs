using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disclaimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisclaimerMessage());
    }

    private IEnumerator DisclaimerMessage()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(11f);
        SceneManagement.LevelComplete();
    }
}
