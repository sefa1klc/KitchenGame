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
        [SerializeField] private GameObject _plateLight;

        private void Start()
        {
            SetType(ItemType.NONE);
            _plateLight.SetActive(false);
        }
        
        public override ItemType GetItem()
        {
            if (GetCurrentType() == ItemType._Plate && _plate._isDone == false) {return ItemType.NONE;}
            else if (_plate._isDone)
            {
                StartCoroutine(ChangeType());
                _plate.ResetPlate();
                return ItemType._Hamburger; 
                
            } else if (_isfull)
            {
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
                _plateLight.SetActive(true);
            
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
                _plateLight.SetActive(false);

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
            CloseItem();
            yield return new WaitForEndOfFrame();
            SetType(ItemType.NONE);
            _isfull = false;
        }

        public void CloseItem()
        {
           _itemsToHold.ForEach(item => item._item.SetActive(false));
        }
        
    }
}