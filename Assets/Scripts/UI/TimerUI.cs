using UnityEngine;
using UnityEngine.UI;
namespace UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Image _clockFilled;

        //for cutting board timer UI
        public void UpdateClock(float amount, float maxValue)
        {
            _clockFilled.fillAmount = amount / maxValue;
        }
    }
}