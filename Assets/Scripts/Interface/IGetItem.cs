using Objects;

namespace Interface
{
    public enum ItemType
    {
        _tomato,_lettuce,_onion,_cheese,_meatball,_bread, _carrot, NONE
    }
    public interface IGetItem
    {
        public ItemType GetItem();
    }
}