using System;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.backpack
{
    public class PickableItems
    {
        private static Dictionary<itemsName, itemType> _ItemByName;
        public static Dictionary<itemsName, itemType> ItemByName { get { if (_ItemByName == null) { load(); } return _ItemByName; } set { _ItemByName = value; } }
        public static List<itemType> _Items;
        public static List<itemType> Items { get { if (_Items == null) { loadList(); return _Items; } return _Items; } set { _Items = value; } }

        

        public static string json = "{\"Itemarr\":[{\"name\":\"red\",\"description\":\"red test\",\"pathToIcon\":\"red\",\"pathToeffectPrefeb\":\"\"},{\"name\":\"green\",\"description\":\"\",\"pathToIcon\":\"green\",\"pathToeffectPrefeb\":\"\"},{\"name\":\"blue\",\"description\":\"\",\"pathToIcon\":\"blue\",\"pathToeffectPrefeb\":\"\"}]}";
        private static void loadList()
        {
            ItemArrObj itemArrObj = JsonUtility.FromJson<ItemArrObj>(json);
            itemType[] ResultArr = itemArrObj.Itemarr;
            _Items = new List<itemType>();
            foreach (itemType itemType in ResultArr)
            {
                _Items.Add(itemType);
            }
        }
        private static void load()
        {
            ItemArrObj itemArrObj = JsonUtility.FromJson<ItemArrObj>(json);
            itemType[] ResultArr = itemArrObj.Itemarr;
            _ItemByName = new Dictionary<itemsName, itemType>();
            foreach (itemType itemType in ResultArr)
            {
                _ItemByName.Add((itemsName)Enum.Parse(typeof(itemsName), itemType.name) , itemType);
            }
        }
public enum itemsName
        {red,green,blue}
    }
}