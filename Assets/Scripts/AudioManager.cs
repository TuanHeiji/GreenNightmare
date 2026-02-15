using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip backGroundScene2Clip;
    [SerializeField] private AudioClip jumbClip;
    [SerializeField] private AudioClip itemClip;
    [SerializeField] private AudioClip menuClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip gameWinClip;
    [SerializeField] private AudioClip shotClip;
    void Start()
    {
        PlayBackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackGroundMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Scene1")
        {
            backgroundAudioSource.clip = backGroundClip;
        }
        else if (currentScene == "Scene2")
        {
            backgroundAudioSource.clip = backGroundScene2Clip;
        }
        backgroundAudioSource.Play();
    }

    public void PlayMenuMusic()
    {
        backgroundAudioSource.clip = menuClip;
        backgroundAudioSource.Play();
    }


    public void PlayItemSound()
    {
        effectAudioSource.PlayOneShot(itemClip);
    }

    public void PlayJumbSound()
    {
        effectAudioSource.PlayOneShot(jumbClip);
    }

    public void PlayShotSound()
    {
        effectAudioSource.PlayOneShot(shotClip);
    }

    public void PlayGameOverSound()
    {
        effectAudioSource.PlayOneShot(gameOverClip);
    }

    public void PlayGameWinSound()
    {
        effectAudioSource.PlayOneShot(gameWinClip);
    }



}
