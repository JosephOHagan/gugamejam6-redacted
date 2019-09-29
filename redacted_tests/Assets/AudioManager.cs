using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public int correctCount = 0;
    public int incorrectCount = 0;

    public int dayCount = 1;

    public Sound[] sounds;

	public static AudioManager instance;

	void Awake () 
	{

		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;

			s.source.loop = s.loop;
		}
		
	}

	public void Start ()
	{
		PlayAudio("MainMenuTheme");
	}


    public void StopAudio (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

	public void PlayAudio (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}
}
