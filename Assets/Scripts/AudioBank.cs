using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    public List<AudioClip> audioclips;

    private void Start()
    {
        audioclips = new List<AudioClip>();
    }
}
