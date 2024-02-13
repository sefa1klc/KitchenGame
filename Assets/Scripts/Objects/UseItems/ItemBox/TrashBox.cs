using Interface;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class TrashBox : MonoBehaviour, IPutItemFull
    {
        public bool PutItem(ItemType item)
        {
            return true;
        }
    }
}