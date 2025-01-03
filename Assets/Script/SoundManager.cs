using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public bool Sound;
    private void Awake()
    {
        instance = this;
        Sound = true;
    }

    [SerializeField] AudioSource AudioSource;

    public void PlaySound(AudioClip Clip,float Volum)
    {
        if (!Sound)
            return;

        AudioSource.PlayOneShot(Clip, Volum);
    }
}
