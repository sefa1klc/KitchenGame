using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
    [System.Serializable]
    public class Sound
    {
        public AudioClip _SoundClips;
        [HideInInspector]
        public AudioSource _source;

        [Header("Attributes")] 
        public string _name;
        [Range(0f , 1f)]
        public float _volume;
        [Range(0.1f , 3f)]
        public float _pitch;
        
        
    }
}