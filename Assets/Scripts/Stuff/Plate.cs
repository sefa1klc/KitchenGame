using System;
using System.Collections.Generic;
using Interface;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stuff
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private List<ObjectnType> _objects = new List<ObjectnType>();
        
        //index of current item for burger
        [SerializeField] private int _currenoObjectstIndex = 0;
        public bool _isDone = false;// check for is hamburger finished
        
        //to put item to plate
        public bool PutItem(ItemType _type)
        {
            if (_currenoObjectstIndex > _objects.Count - 1) return false;
            //if the item which trying to put the plate, we active this item
            if (_type == _objects[_currenoObjectstIndex]._type)
            {
                _objects[_currenoObjectstIndex]._item.SetActive(true);
                _currenoObjectstIndex++;
                if (_currenoObjectstIndex > _objects.Count - 1)
                {
                    _isDone = true;
                }
                return true;
            }
            return false;
        }
        
        public void ResetPlate()
        {
            _isDone = false;
            _currenoObjectstIndex = 0;
            foreach (ObjectnType obj in _objects)
            {
                obj._item.SetActive(false);
            }
        }
    }
}