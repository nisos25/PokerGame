using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private AudioManager audioManager;
	
    private void Awake()
    {
	    audioManager = FindObjectOfType<AudioManager>();
	    
	    if (audioManager != this)
	    {
		    Destroy(gameObject);
	    }
	    
		DontDestroyOnLoad(transform.gameObject);   
    }
}
