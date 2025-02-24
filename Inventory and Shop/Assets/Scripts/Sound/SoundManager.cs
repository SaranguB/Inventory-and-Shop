using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField]
    private AudioSource soundEffect;

    [SerializeField]
    private SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(Sounds sound)
    {
        SoundType soundType = GetSoundType(sound);

        if (soundType != null)
        {
            soundEffect.volume = soundType.volume;
            soundEffect.PlayOneShot(soundType.soundClip);
        }
    }

    private SoundType GetSoundType(Sounds sound)
    {
        SoundType type = Array.Find(sounds, i => i.sound == sound);

        return type;

    }


}

[Serializable]
public class SoundType
{
    public Sounds sound;
    public AudioClip soundClip;

    [Range(1, 100)]
    public int volume;
}

public enum Sounds
{
    ShopInventorySwitchButton,
    ItemSelected,
    QuantityChanged,
    MoneySound,
    FilterButtonSound,
    ErrorSound,
    NonClickable,
    GatherResource
}
