using System;
using System.Collections;
using Abstract;
using Interface;
using JetBrains.Annotations;
using Objects.UseItems.ItemBox;
using UnityEngine;

namespace Player
{
    public class ActionController : MonoBehaviour
    {
        private Animator anim;
        private Inventory _inventory;
        public GameObject _particle;
        private bool _isWorking = false;
        private Functionality _currentFunction;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            _inventory = GetComponent<Inventory>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoAction();
            }
            else if (Input.GetMouseButton(0))
            {
                if (_isWorking == false)
                {
                    StartProcessAction();
                }
                else
                {
                    DoProcessAction();
                }   
            }else if (Input.GetMouseButtonUp(0))
            {
                if (_isWorking)
                {
                    _currentFunction?.ResetTimer();
                }
            }
        }

        private void DoAction()
        {
            anim.SetTrigger("_Take");
            
        }

        //for draw ray
        //public void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawLine(transform.position + Vector3.up , transform.position + Vector3.up + transform.forward );
        //}

        public void DoTakeAction()
        {
            StartCoroutine(Particle());
            //create a ray from position to forward
            Ray ray = new Ray(transform.position + Vector3.up /2, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 1))
            {
                //if raycast hit something has ItemBox class
                if (hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
                {
                    //Get the item held by the ItemBox
                    _inventory.TakeItem(itemBox.GetItem());
                }
                
                if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
                {
                    bool status = itemPutBox.PutItem(_inventory.GetItem());
                    if (status == true)
                    {
                        _inventory.PutItem();
                        _inventory.ClearHand();
                    }
                }
            }
        }

        private IEnumerator Particle()
        {
            _particle.SetActive(true);
            yield return new WaitForSeconds(1f);
            _particle.SetActive(false);
        }

        public void StartProcessAction()
        {
            //create a ray from position to forward
            Ray ray = new Ray(transform.position + Vector3.up /2, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 1))
            {
                //if raycast hit something has Functionality class
                if (hit.collider.TryGetComponent<Functionality>(out Functionality itemProcess))
                {
                    _isWorking = true;
                    _currentFunction = itemProcess;
                }
                else
                {
                    _isWorking = false;
                }
            }
        }

        private void DoProcessAction()
        {
            if (!_isWorking) return;
            ItemType item = _currentFunction.Process();
            cuttingAnimBool();

            if (item != ItemType.NONE)
            {
                _currentFunction.ClearObject();
                _inventory.TakeItem(item);
                _isWorking = false;
            }
        }

        public bool cuttingAnimBool()
        {
            return true;
        }
    }
}