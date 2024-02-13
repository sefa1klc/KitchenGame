using Objects;

namespace Interface
{
    public enum ItemType
    {
        _tomato,_lettuce,_onion,_cheese,_meatball,_bread, _carrot, NONE,
        _Slicedtomato,_Slicedlettuce,_Scliedonion,_Sclicedcheese,_Cookedmeatball,_Slicedbread, _Slicedcarrot
        
    }
    public interface IGetItem
    {
        public ItemType GetItem();
    }
}