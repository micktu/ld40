using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> Blasts = new List<AudioClip>();

    public List<AudioClip> Heats = new List<AudioClip>();

    public void PlayBlast(GameObject target)
    {
        target.AddComponent<AudioSource>();
    }


}
