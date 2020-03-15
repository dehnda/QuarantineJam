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
    public static AudioClip jumpSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        if (jumpSound == null) Debug.LogError("jump ogg not found");
        audioSrc = GetComponent<AudioSource> ();
    }

    public static void PlaySound(Sounds sound){

        switch (sound) {
            case Sounds.JUMP:
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
    }
}
