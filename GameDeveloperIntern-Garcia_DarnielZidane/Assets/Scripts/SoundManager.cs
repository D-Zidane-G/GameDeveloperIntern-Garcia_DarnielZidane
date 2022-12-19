using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;

    [Header("Game BG Music")]
    public AudioClip MainMenuMusic;
    public AudioClip InGameMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        AudioSource musicSource = _musicSource.gameObject.GetComponent<AudioSource>();
        _musicSource.PlayOneShot(MainMenuMusic);
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public IEnumerator StartIGMusicTransition()
    {
        _musicSource.Stop();
        _musicSource.volume = 0f;
        yield return new WaitForSeconds(2f);
        _musicSource.PlayOneShot(InGameMusic);
        _musicSource.volume = 1f;
    }

    public IEnumerator StartMenuMusicTransition()
    {
        _musicSource.Stop();
        _musicSource.volume = 0f;
        yield return new WaitForSeconds(0.5f);
        _musicSource.PlayOneShot(MainMenuMusic);
        _musicSource.volume = 1f;
    }
}
