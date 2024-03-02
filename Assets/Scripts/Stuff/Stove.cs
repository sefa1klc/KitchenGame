using System;
using Abstract;
using Interface;
using Objects.UseItems.ItemBox;
using Sounds;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stuff
{
    public class Stove : MonoBehaviour , IPutItemFull
    {
        private bool _isFull;
        [SerializeField] private GameObject cookedItem;
        [SerializeField] private GameObject Fire;
        [SerializeField] private TimerUI _timer;
        [SerializeField] private float CookTime;
        [SerializeField] private StoveBox stoveBox;
        private float _currenTime;

        private void Start()
        {
            _timer.gameObject.SetActive(false);
            cookedItem.SetActive(false);
            Fire.SetActive(false);
        }


        private void Update()
        {
            if (_isFull)
            {
                _currenTime += Time.deltaTime;
                _timer.UpdateClock(_currenTime, CookTime);
                if (_currenTime >= CookTime)
                {
                    _currenTime = 0;
                    _timer.gameObject.SetActive(false);
                    Fire.SetActive(false);
                    cookedItem.SetActive(true);
                    stoveBox.SetType(ItemType._Cookedmeatball);
                    stoveBox.canTake = true;
                    _isFull = false;
                }
            }
        }

        public void CloseCookedMeat()
        {
            cookedItem.SetActive(false);
        }

        public bool PutItem(ItemType item)
        {
            if (item != ItemType._meatball) return false;
            if (_isFull) return false;
            _timer.gameObject.SetActive(true);
            Fire.SetActive(true);
            //to play the audioclip with to find SoundManager script
            FindObjectOfType<SoundManager>().PlayAudioClip("StoveTimer");
            FindObjectOfType<SoundManager>().PlayAudioClip("CookFrying");
            FindObjectOfType<SoundManager>().PlayAudioClip("StoveFire");
            _isFull = true;
            return true;
        }
    }
}