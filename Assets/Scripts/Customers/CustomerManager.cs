using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Customers
{
    public class CustomerManager : MonoBehaviour
    {
        public static CustomerManager Instance;
        [SerializeField] private float _timerSpeed = 1f;
        [SerializeField] private List<Customer> _customersList = new List<Customer>();
        [SerializeField] private List<Customer> _customerPrefabs = new List<Customer>();
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _exitPoint;
        private float _currentTime = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (_currentTime <= Random.Range(50, 80))
            {
                _currentTime += Time.deltaTime * _timerSpeed;
            }
            else
            {
                _currentTime = 0;
                Vector3 _spawnPos = _spawnPoint.position + (_spawnPoint.forward * -1 * _customersList.Count * 3) + (_spawnPoint.right * Random.Range(-1f, 1f ));
                Customer temp = Instantiate(_customerPrefabs[Random.Range(0, _customerPrefabs.Count)], _spawnPos, _spawnPoint.rotation);
                _customersList.Add(temp);
            }
        }

        public void SellToCustomer()
        {
            if (_customersList.Count == 0) return;
            
            Customer firstCustomer = _customersList[0];
            firstCustomer.ExitFromRestaurant(_exitPoint.position);
            _customersList.Remove(firstCustomer);
            
            for (int i = 0; i < _customersList.Count; i++)
            {
                Vector3 _nextPos = _spawnPoint.position + (_spawnPoint.forward * -1 * i * 3) + (_spawnPoint.right * Random.Range(-1f, 1f ));
                _customersList[i].MoveNextPosition(_nextPos);
            }
            
        }
    }
}