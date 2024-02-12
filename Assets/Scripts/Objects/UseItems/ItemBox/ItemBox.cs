using Interface;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class ItemBox: MonoBehaviour, IGetItem
    {
        [SerializeField] private ItemType _item;
        
        public ItemType GetItem()
        {
            return _item;
        }
    }
}