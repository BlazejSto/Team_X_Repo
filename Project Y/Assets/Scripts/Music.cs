using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public Camera cam;
    public AudioSource camAudio;
    public AudioClip eMusic;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camAudio = cam.GetComponent<AudioSource>();
        camAudio.PlayOneShot(eMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
