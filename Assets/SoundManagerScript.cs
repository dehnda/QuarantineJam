using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public enum Sounds
{
    JUMP,
    SHOOT,
    GOODCATCH,
    BADCATCH,
    IMPACT,
    DEATH

}
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, shootSound, goodSound, badSound, deathSound;
    static AudioSource audioSrc;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        shootSound = Resources.Load<AudioClip>("shoot");
        goodSound = Resources.Load<AudioClip>("good");
        badSound = Resources.Load<AudioClip>("bad");
        deathSound = Resources.Load<AudioClip>("death");
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
            case Sounds.GOODCATCH:
                audioSrc.PlayOneShot(goodSound);
                break;
            case Sounds.BADCATCH:
                audioSrc.PlayOneShot(badSound);
                break;
            case Sounds.DEATH:
                audioSrc.PlayOneShot(deathSound);
                break;
        }
    }
}
