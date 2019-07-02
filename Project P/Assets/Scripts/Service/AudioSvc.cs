/****************************************************
    文件：AudioSvc.cs
	作者：Project P Group
    邮箱: 389371356@qq.com
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour {
    public static AudioSvc Instance = null;
    public AudioSource bgAudio;
    public AudioSource uiAudio;

    public void InitSvc() {
        Instance = this;
        
        Debug.Log("Init AudioSvc...");
    }

    public void InitAudioSource()
    {
        AudioSource[] audioSources = transform.GetComponents<AudioSource>();
        bgAudio = audioSources[0];
        uiAudio = audioSources[1];
    }
    public void PlayBGMusic(string name, bool isLoop = true) {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if (bgAudio.clip == null || bgAudio.clip.name != audio.name) {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    public void PlayUIAudio(string name) {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        uiAudio.clip = audio;
        uiAudio.Play();
    }

    public void PlayCharAudio(string name, AudioSource audioSource)
    {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        audioSource.clip = audio;
        audioSource.Play();
    }
}