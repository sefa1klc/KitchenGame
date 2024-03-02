using System;
using System.Collections;
using Abstract;
using Customers;
using Interface;
using JetBrains.Annotations;
using Objects.UseItems.ItemBox;
using Sounds;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace Player
{
    public class ActionController : MonoBehaviour
    {
        private Animator anim;
        private Inventory _inventory;
        public GameObject _particle;
        private bool _isWorking = false;
        private bool _isProccessing = false;
        private Functionality _currentFunction;
        private bool _canTake = true;
        private WaitForSeconds _takeCoolDown;
        public GameObject _recipe;
        public TextMeshProUGUI _coinText;
        public float _moneyCounter = 0f;
        private float increase = 100f;

        private void Awake()
        {
            _canTake = true;
            anim = GetComponent<Animator>();
            _inventory = GetComponent<Inventory>();
            _takeCoolDown = new WaitForSeconds(0.5f);
        }

        private void Start()
        {
            _recipe.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                _recipe.SetActive(true);
            }
            else
            {
                _recipe.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                DoAction();
            }
            else if (Input.GetMouseButton(0))
            {
                _isWorking = true;
                if (_isProccessing == false)
                { 
                    StartProcessAction();
                }
                else
                {
                    DoProcessAction();
                }   
            }else if (Input.GetMouseButtonUp(0))
            {
                _isWorking = false;
                if (_isProccessing)
                {
                    _currentFunction?.ResetTimer();
                    _isProccessing = false;
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
                if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
                {
                    if(_canTake){
                        bool status = itemPutBox.PutItem(_inventory.GetItem());
                        if (status == true)
                        {
                            _inventory.PutItem();
                            _inventory.ClearHand();
                        }
                    }
                }
                
                //if raycast hit something has ItemBox class
                if (hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
                {
                    //Get the item held by the ItemBox
                    _inventory.TakeItem(itemBox.GetItem());
                    StartCoroutine(CanTakeController());
                }
                
            }
        }

        private IEnumerator CanTakeController()
        {
            _canTake = false;
            yield return _takeCoolDown;
            _canTake = true;
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
                    _isProccessing = true;
                    _currentFunction = itemProcess;
                }
            }
        }

        private void DoProcessAction()
        {
            if (!_isProccessing) return;
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

        private void OnTriggerStay(Collider other)
        {
            if (_inventory._currentItem != ItemType._Hamburger) return;
            if (other.gameObject.CompareTag("Sellarea"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CustomerManager.Instance.SellToCustomer();
                    _inventory.ClearHand();
                    FindObjectOfType<SoundManager>().PlayAudioClip("Coins");
                    _moneyCounter += increase;
                    _coinText.text = _moneyCounter.ToString();
                }
            }
        }
        
    }
}