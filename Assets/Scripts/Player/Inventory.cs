using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Objects;
using UnityEngine;

namespace Player
{   
    [System.Serializable]// to see inspector
    public class ObjectnType
    {
        public GameObject _item;
        public ItemType _type;
    }
    public class Inventory : MonoBehaviour
    {
        //all items list in player hands. first of all, off the item visibility and If he take an item, I will turn on the visibility of whatever item he took.
        //so we do not need any spawn 
        [SerializeField] private List<ObjectnType> _itemsToHold = new List<ObjectnType>();
        
        private ItemType _currentItem;

        private void Start()
        {
            _currentItem = ItemType.NONE;
        }

        public void TakeItem(ItemType _itemType)
        {
            if (_currentItem != ItemType.NONE) return;
            _currentItem = _itemType;
            
            //we decide to which one may appear
            foreach (ObjectnType itemHold in _itemsToHold)
            {
                if (itemHold._type != _itemType)
                {
                    itemHold._item.SetActive(false);
                }
                else
                {
                    itemHold._item.SetActive(true);
                }
            }
            
        }

        public ItemType PutItem()
        {
            if (_currentItem == ItemType.NONE) return ItemType.NONE;
            _itemsToHold.ForEach(obj => obj._item.SetActive(false));
            return _currentItem;
        }

        public void ClearHand()
        {
            _currentItem = ItemType.NONE;
        }
        public ItemType GetItem()
        {
            return _currentItem;
        }

    }
}