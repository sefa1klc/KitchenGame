using Interface;
using UI;
using UnityEngine;

namespace Abstract
{
    public abstract class Functionality : MonoBehaviour
    {
        // keep the cutting or cooking time
        public float _maxTime;
        public float _currentTime;
        public TimerUI _Timer;
        public bool Processtarted;

        public virtual ItemType Process()
        {
            return ItemType.NONE;
        }

        public virtual void ClearObject()
        {
            
        }
        
        public void ResetTimer()
        {
            _currentTime = 0;
            _Timer.gameObject.SetActive(false);
            _Timer.UpdateClock(_currentTime, _maxTime);
        }
    }
}