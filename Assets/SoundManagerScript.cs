using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public enum Sounds
{
    JUMP,
    SHOOT
}
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, shootSound;
    static AudioSource audioSrc;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        shootSound = Resources.Load<AudioClip>("shoot");
        audioSrc = GetComponent<AudioSource> ();
    }

    public static void PlaySound(Sounds sound){

        switch (sound) {
            case Sounds.JUMP:
                audioSrc.PlayOneShot(jumpSound);
                break;
            case Sounds.SHOOT:
                audioSrc.PlayOneShot(shootSound);
                break;
        }
    }
}
