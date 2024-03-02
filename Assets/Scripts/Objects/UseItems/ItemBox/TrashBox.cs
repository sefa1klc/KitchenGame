using Interface;
using Sounds;
using UnityEngine;

namespace Objects.UseItems.ItemBox
{
    public class TrashBox : MonoBehaviour, IPutItemFull
    {
        public bool PutItem(ItemType item)
        {
            FindObjectOfType<SoundManager>().PlayAudioClip("Trash");
            return true;
        }
    }
}