using System;
using Objects.UseItems.ItemBox;
using UnityEngine;

namespace Player
{
    public class ActionController : MonoBehaviour
    {
        private Animator anim;
        private Inventory _inventory;

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
            }else if (Input.GetMouseButton(0))
            {
                
            }else if (Input.GetMouseButtonUp(0))
            {
                
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
            }
        }
    }
}