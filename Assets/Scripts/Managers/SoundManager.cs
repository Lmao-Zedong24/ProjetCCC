using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] GameObject soundPrefab;
    [Serializable]
    public struct SoundInfo
    {
        public ESoundName   uniqueName;
        public AudioClip    sound;
    }
    public SoundInfo[] soundClips;

    Dictionary<ESoundName, AudioClip> _soundDictionnary;
    Transform    _cam;

    public enum ESoundName
    {
        DEFAULT,
        ON_ARM1_EXTEND,
        ON_ARM2_EXTEND,
        ON_ARM3_EXTEND,
    }



    protected override void Awake()
    {
        base.Awake();

        _soundDictionnary = new Dictionary<ESoundName, AudioClip>();
        foreach (var pair in soundClips)
            _soundDictionnary.Add(pair.uniqueName, pair.sound);

        soundClips = null;
        _cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    IEnumerator SoundRoutine(AudioSource audio)
    {
        audio.Play();

        while (audio.isPlaying) 
            yield return new WaitForSeconds(1f);

        Destroy(audio.gameObject);
    }

    public void PlaySound(ESoundName name)
    {
        if (!_soundDictionnary.ContainsKey(name) || _soundDictionnary[name] == null)
            return;

        var soundObj = Instantiate(new GameObject("audio obj"), _cam);
        var audio = soundObj.AddComponent<AudioSource>();

        audio.clip = _soundDictionnary[name];
        StartCoroutine(SoundRoutine(audio));
    }
}
