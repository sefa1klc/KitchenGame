using System;
using System.Collections.Generic;
using Interface;
using Player;
using UnityEngine;

namespace Stuff
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private List<ObjectnType> _objects = new List<ObjectnType>();
        
        //index of current item for burger
        [SerializeField] private int _currenoObjectstIndex = 0;
        
        //to put item to plate
        public bool PutItem(ItemType _type)
        {
            //if the item which trying to put the plate, we active this item
            if (_type == _objects[_currenoObjectstIndex]._type)
            {
                _objects[_currenoObjectstIndex]._item.SetActive(true);
                _currenoObjectstIndex++;
                return true;
            }
            return false;
        }
    }
}