using Interface;
using Stuff;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class TableBox : ItemBox
    {
        public MiddleTable _mtable;
        public bool canTake;
        public override ItemType GetItem()
        {
            if (!canTake) return ItemType.NONE;
            _mtable.CloseItem();
            canTake = false;
            return base.GetItem();
        }
    }
}