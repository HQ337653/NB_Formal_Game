using UnityEngine;

// the data structure of all things that can be pick up and put into the backpack. all the sprite and the game effect object should be putted in a resources folder 
//because only instance id will be saved in json file, save and load by file name instead
namespace NBGame.backpack
{
    [System.Serializable]
    public class itemType 
    {
        public string name;
        public string description;
        public Sprite icon
        {
            get { if (pathToIcon != null) { return Resources.Load<Sprite>(pathToIcon); } else return null; }
            set { if (value != null) { pathToIcon = value.name; };  }
        }
        public string pathToIcon;
        public GameObject effectPrefeb
        {
            get { if (pathToeffectPrefeb != null) { return Resources.Load<GameObject>(pathToeffectPrefeb); } else return null; }
            set { if (value != null) { pathToeffectPrefeb = value.name; };  }
        }
        public string pathToeffectPrefeb;


    }
}