using System;
using Interface;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class ItemBox: MonoBehaviour, IGetItem
    {
        [SerializeField] private ItemType _item;
        
        public virtual ItemType GetItem()
        {
            return _item;
        }

        public void SetType(ItemType type)
        {
            _item = type;
        }

    }
}