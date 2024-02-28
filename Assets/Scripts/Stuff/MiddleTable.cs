using System;
using System.Collections.Generic;
using Interface;
using Objects;
using Objects.UseItems.ItemBox;
using Player;
using UnityEngine;

namespace Stuff
{
    public class MiddleTable : MonoBehaviour, IPutItemFull
    {
        //List of Enum
        [SerializeField] private List<ObjectnType> _itemsToHold = new List<ObjectnType>();
        [SerializeField] private TableBox _tableBox;
        private ItemType _currentItem;

        private void Start()
        {
            _currentItem = ItemType.NONE;
        }

        public bool PutItem(ItemType item)
        {
            if (_tableBox.canTake) return false;
            if (_currentItem != ItemType.NONE) return false;
            _currentItem = item;
            _tableBox.canTake = true;
            
            _tableBox.SetType(_currentItem);
            
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

        public void CloseItem()
        {
           _itemsToHold.ForEach(item => item._item.SetActive(false));
           _currentItem = ItemType.NONE;
        }
    }
}