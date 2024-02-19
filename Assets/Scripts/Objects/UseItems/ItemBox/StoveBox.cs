using Interface;
using Stuff;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class StoveBox : ItemBox
    {
        [SerializeField] private Stove stove;
        public bool canTake;
        public override ItemType GetItem()
        {
            if (!canTake) return ItemType.NONE;
            stove.CloseCookedMeat();
            canTake = false;
            return base.GetItem();
        }
        
        
    }
        
}