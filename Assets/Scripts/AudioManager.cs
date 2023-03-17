using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Audio;
    public AudioSource Source;

    internal void Playsound()
    {
        Audio.Source.Play();
    }

    private void Awake()
    {
        if(Audio == null)
        {
            Audio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(Audio != this)
            {
                Destroy(gameObject);
            }
        }

        Source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
