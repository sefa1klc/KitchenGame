using System;
using System.Collections;
using UnityEngine;

namespace Stuff
{
    public class Knife : MonoBehaviour
    {
        public static Knife Instance;
        private Animator _anim;
        private CuttingBoard _cb;
        public GameObject _particle;

        private void Awake()
        {
            Instance = this;
            _anim = GetComponent<Animator>();
        }
        
        public void CuttingAnim()
        {
            _anim.SetBool("isCutting",true);
        }
        
        private IEnumerator Particle()
        {
            _particle.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            _particle.SetActive(false);
        }
    }
}