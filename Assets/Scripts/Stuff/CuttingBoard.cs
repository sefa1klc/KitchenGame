using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using Abstract;
using Interface;
using Player;
using UnityEngine;

namespace Stuff
{
    public class CuttingBoard: Functionality, IPutItemFull
    {
        [SerializeField] private List<ObjectnType> _itemsToHold = new List<ObjectnType>();
        private ItemType _currentItem;
        
        private void Start()
        {
            _currentItem = ItemType.NONE;
            _Timer.gameObject.SetActive(false);

        }

        public override ItemType Process()
        {
            if (_currentItem == ItemType.NONE) return ItemType.NONE;;

            if (Processtarted == true && _Timer.gameObject.activeSelf == false)
            {
                _Timer.gameObject.SetActive(true);
            }
            
            Processtarted = true;
            
            _currentTime += Time.deltaTime;
            _Timer.UpdateClock(_currentTime, _maxTime);
            if (_currentTime >= _maxTime)
            {
                _currentTime = 0;
                Processtarted = false;
                _Timer.gameObject.SetActive(false);
                _Timer.UpdateClock(_currentTime, _maxTime);
                switch (_currentItem)
                {
                    case ItemType._tomato:
                        return ItemType._Slicedtomato;
                    case ItemType._lettuce:
                        return ItemType._Slicedlettuce;
                    case ItemType._onion:
                        return ItemType._Scliedonion;
                    case ItemType._cheese:
                        return ItemType._Sclicedcheese;
                    case ItemType._bread:
                        return ItemType._Slicedbread;
                    case ItemType._carrot:
                        return ItemType._Slicedcarrot;
                }
            }
            return ItemType.NONE;
        }


        public override void ClearObject()
        {
            base.ClearObject();
            _currentItem = ItemType.NONE;
            _itemsToHold.ForEach(obj => obj._item.SetActive(false));
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