using System;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public Sound[] _audioClips;
        
        private void Awake()
        {
            foreach (Sound _clips in _audioClips)
            {
                _clips._source = gameObject.AddComponent<AudioSource>();
                _clips._source.clip = _clips._SoundClips;

                _clips._source.volume = _clips._volume;
                _clips._source.pitch = _clips._pitch;
                

            }
        }

        public void PlayAudioClip(string _name)
        {
            Sound _playebleSound = Array.Find(_audioClips, sound => sound._name == _name);
            _playebleSound._source.Play();
        }
        
        public void StopAudioClip(string _name)
        {
            Sound _playebleSound = Array.Find(_audioClips, sound => sound._name == _name);
            _playebleSound._source.Stop();
        }
    }
}