using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.PlayerSettings;

public class SoundManager : Singleton<SoundManager>
{
    //SoundManager.Instance.PlaySound("CharacterWalk", transform);


    [Serializable]
    public struct SoundInfo
    {
        public string uniqueName;
        public AudioClip    sound;
    }
    public SoundInfo[] soundClips;

    Dictionary<string, AudioClip> _soundDictionnary;
    Transform    _cam;

    protected override void Awake()
    {
        base.Awake();

        _soundDictionnary = new Dictionary<string, AudioClip>();
        foreach (var pair in soundClips)
            _soundDictionnary.Add(pair.uniqueName, pair.sound);

        soundClips = null;
        _cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    IEnumerator SoundRoutine(AudioSource audio, bool isLoop = false)
    {
        audio.Play();

        while (audio.isPlaying) 
            yield return new WaitForSeconds(1f);

        if (isLoop)
            StartCoroutine(SoundRoutine(audio, isLoop));
        else
            Destroy(audio.gameObject);
    }

    public void PlaySoundLoop(string name)
    {
        if (!_soundDictionnary.ContainsKey(name) || _soundDictionnary[name] == null)
        {
            Debug.Log("Name Not found or no sound attached to name: " + name);
            return;
        }

        var soundObj = Instantiate(new GameObject("audio obj"), _cam);
        var audio = soundObj.AddComponent<AudioSource>();

        audio.clip = _soundDictionnary[name];
        StartCoroutine(SoundRoutine(audio, true));
    }

    public void PlaySound(string name, Transform pos = null, float volume = 1.0f)
    {
        if (!_soundDictionnary.ContainsKey(name) || _soundDictionnary[name] == null)
        {
            Debug.Log("Name Not found or no sound attached to name: " + name);
            return;
        }
        var soundObj = Instantiate(new GameObject("audio obj"), pos == null? _cam: pos);
        var audio = soundObj.AddComponent<AudioSource>();

        audio.clip = _soundDictionnary[name];
        audio.volume = volume;
        StartCoroutine(SoundRoutine(audio));
    }
}
