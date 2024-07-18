
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource Walking;
    public AudioClip Background;
    public AudioClip Walk;
    public AudioClip Ball_destroy;
    public AudioClip collider_off;
    public AudioClip Bridge;
    public AudioClip slingshot;
    public AudioClip Alphabet_click;
    public AudioClip Ball_collision;
    public AudioClip Level_completed;

    private void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }
    public void Playsfx(AudioClip clip)
    {
        SFX.clip = clip;
        SFX.Play();
    }
    public void Walkig(AudioClip clip)
    {
        SFX.clip = clip;
        Walking.Play();
    }
}
