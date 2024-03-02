using System;
using Interface;
using Sounds;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class ItemBox: MonoBehaviour, IGetItem
    {
        [SerializeField] private ItemType _item;
        
        public virtual ItemType GetItem()
        {
            FindObjectOfType<SoundManager>().PlayAudioClip("PickUp");
            FindObjectOfType<SoundManager>().PlayAudioClip("Particle");
            return _item;
        }

        public void SetType(ItemType type)
        {
            _item = type;
        }

        public ItemType GetCurrentType()
        {
            return _item;
        }

    }
}