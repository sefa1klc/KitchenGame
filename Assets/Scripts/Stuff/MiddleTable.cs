using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Objects;
using Objects.UseItems.ItemBox;
using Player;
using UnityEngine;

namespace Stuff
{
    public class MiddleTable : ItemBox, IPutItemFull
    {
        //List of Enum
        [SerializeField] private List<ObjectnType> _itemsToHold = new List<ObjectnType>();
        [SerializeField] private bool _isfull = false;
        [SerializeField] private Plate _plate;

        private void Start()
        {
            SetType(ItemType.NONE);
        }
        
        public override ItemType GetItem()
        {
            if (GetCurrentType() == ItemType._Plate) return ItemType.NONE;
            if (_isfull)
            {
                _isfull = false;
                CloseItem();
                StartCoroutine(ChangeType());
                return base.GetItem();
            }

            return ItemType.NONE;
        }

        public bool PutItem(ItemType item)
        {
            if (!_isfull)
            {
                SetType(item);
            
                //we decide to which one may appear
                foreach (ObjectnType itemHold in _itemsToHold)
                {
                    if (itemHold._type != GetCurrentType())
                    {
                        itemHold._item.SetActive(false);
                    }
                    else
                    {
                        itemHold._item.SetActive(true);
                    }
                }

                StartCoroutine(PutCoolDown());
                return true;
            }
            else
            {
                if (GetCurrentType() == ItemType._Plate)
                {
                    if (item != ItemType._Plate)
                    {
                        StartCoroutine(PutCoolDown());
                        return _plate.PutItem(item);
                    }
                }
            }

            return false;
        }

        private IEnumerator PutCoolDown()
        {
            yield return new WaitForEndOfFrame();
            _isfull = true;
        }
        
        private IEnumerator ChangeType()
        {
            yield return new WaitForEndOfFrame();
            SetType(ItemType.NONE);
        }

        public void CloseItem()
        {
           _itemsToHold.ForEach(item => item._item.SetActive(false));
        }
    }
}