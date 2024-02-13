using System;
using System.Collections.Generic;
using Interface;
using Player;
using UnityEngine;

namespace Stuff
{
    public class CuttingBoard: MonoBehaviour, IPutItemFull
    {
        [SerializeField] private List<ObjectnType> _itemsToHold = new List<ObjectnType>();
        private ItemType _currentItem;

        private void Start()
        {
            _currentItem = ItemType.NONE;
        }

        public bool PutItem(ItemType item)
        {
            if (_currentItem != ItemType.NONE) return false;
            _currentItem = item;
            
            //we decide to which one may appear
            foreach (ObjectnType itemHold in _itemsToHold)
            {
                if (itemHold._type != item)
                {
                    itemHold._item.SetActive(false);
                }
                else
                {
                    itemHold._item.SetActive(true);
                }
            }

            return true;
        }
    }
}