using System;
using UnityEngine;
using DG.Tweening;

namespace Customers
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private GameObject burger;

        private void Start()
        {
            burger.SetActive(false);
        }

        public void ExitFromRestaurant(Vector3 pos)
        {
            burger.SetActive(true);
            transform.DOMove(pos, 3).OnComplete(() => { Destroy(this.gameObject);});
        }

        public void MoveNextPosition(Vector3 pos)
        {
            
            transform.DOMove(pos, 2);
        }
    }
}