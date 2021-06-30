using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, startSound, failSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("OOJump");
        startSound = Resources.Load<AudioClip>("Start");
        failSound = Resources.Load<AudioClip>("UH oh");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Oo":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "Start":
                audioSrc.PlayOneShot(startSound);
                break;
            case "UH oh":
                audioSrc.PlayOneShot(failSound);
                break;
        }
    }
}
