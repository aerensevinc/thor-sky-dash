using System.Collections.Generic;
using System.Collections;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<Sound> soundList;
    public AudioSource effectSource;
    public AudioSource musicSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void PlaySound(string key, bool isEffect)
    {
        AudioSource source = isEffect ? effectSource : musicSource;
        string volumeKey = isEffect ? PlayerPrefsKeys.effectsVol : PlayerPrefsKeys.musicVol;
        float gameVolume = PlayerPrefs.GetFloat(volumeKey, 1);
        foreach (Sound sound in soundList)
        {
            if (sound.key == key)
            {
                source.clip = sound.clip;
                source.volume = sound.volume * gameVolume;
                source.Play();
                if (!isEffect) source.loop = true;
            }
        }
    }

    public void SlowDownMusic(float duration)
    {
        StartCoroutine(SlowDownMusicRoutine(duration));
    }

    private IEnumerator SlowDownMusicRoutine(float duration)
    {
        musicSource.pitch = 0.93f;
        yield return new WaitForSeconds(duration);
        musicSource.pitch = 1f;
    }
}

[System.Serializable]
public class Sound
{
    public string key;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
}