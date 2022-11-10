using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

namespace NBGame.backpack
{
    //make a window that can make Item in NbGame/pickableObject
    // will generate a PickableItems class that have itemName enum with all object name in it, can get the object by PickableItems._ItemByName
    public class pickableItemWindow : EditorWindow
    {

        [SerializeField]
        private List<itemType> itemList;
        [MenuItem("NbGame/pickableObject")]
        public static void ShowWindow()
        {
            GetWindow<pickableItemWindow>("pickableObject");
        }
        public void  Awake()
        {
            itemList = new List<itemType>();

                for (int i = 0; i < PickableItems.Items.Count; i++)
                {
                    NotFolds.Add(true);
                    itemList.Add(new itemType());
                    itemList[i].name = PickableItems.Items[i].name;
                    itemList[i].description = PickableItems.Items[i].description;
                    itemList[i].icon = PickableItems.Items[i].icon;
                    itemList[i].effectPrefeb = PickableItems.Items[i].effectPrefeb;
                }
            
        }
        void OnDestroy()
        {
            itemList = null;
        }
        List<bool> NotFolds = new List<bool>();
        Vector2 scrollPos;
        public void OnGUI() 
        {
            scrollPos =EditorGUILayout.BeginScrollView(scrollPos);
            if (itemList!=null) {
                for (int i = 0; i < itemList.Count; i++)
                {

                    displayItem(i);

                }
                EditorGUILayout.EndScrollView();
                bool showRestContent=true;
                for (int i = 0; i < itemList.Count; i++)
                {

                    if (itemList[i].name == null || itemList[i].name.Length == 0)
                    {
                        showRestContent=false;
                    }

                }
                if (showRestContent) {
                    if (GUILayout.Button("Save"))
                    {
                        save();
                    }
                    if (GUILayout.Button("add"))
                    {
                        NotFolds.Add(true);
                        itemList.Add(new itemType());
                    }
                }
                if (GUILayout.Button("Collapse all"))
                {
                    for(int i=0; i< NotFolds.Count; i++)
                    {
                        NotFolds[i] = false;
                    }
                }
                
            }
        }

        public void displayItem(int i)
        {
            if (itemList[i] == null)
            {
                itemList[i] = new itemType();
            }
            NotFolds[i] = EditorGUILayout.Foldout(NotFolds[i], itemList[i].name, EditorStyles.foldout);
            if (NotFolds[i]) {
                {
                    
                        itemList[i].name = (string)EditorGUILayout.TextField("Name", itemList[i].name);
                    
                    itemList[i].icon = (Sprite)EditorGUILayout.ObjectField(itemList[i].icon, typeof(Sprite));
                    itemList[i].description = (string)EditorGUILayout.TextField("description", itemList[i].description);
                    itemList[i].effectPrefeb = (GameObject)EditorGUILayout.ObjectField(itemList[i].effectPrefeb, typeof(GameObject));
                    if (GUILayout.Button("Remove"))
                    {
                        itemList.Remove(itemList[i]);
                        NotFolds.RemoveAt(i);
                    }
                }
            }
        }
        #region save
        public void save()
        {
            //cheak if all names are filled out
            for (int i = 0; i < itemList.Count; i++)
            {

                if (itemList[i].name==null|| itemList[i].name.Length==0)
                {
                    Debug.Log("failed saving");
                    return;
                }

            }
            //generate script
            string fullPath = Application.dataPath + "/backpackSystem/Item/PickableItems.cs";
          try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                         writer.Write(generate());
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("error trying to get the path: " + fullPath);
            }
            Debug.Log("finished saving");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        string generate()
        {
            //generate json string
            string result;
            itemType[]  Itemarr = itemList.ToArray();
            ItemArrObj itemarrObj = new ItemArrObj();
            itemarrObj.Itemarr = Itemarr;
            string originalJson = JsonUtility.ToJson(itemarrObj);
            originalJson =originalJson.Replace("\"","\\\"");
            ItemArrObj r = JsonUtility.FromJson<ItemArrObj>(JsonUtility.ToJson(new ItemArrObj()));
            result = start + originalJson + "\";"+ loadMethod+ EnumStart;
            bool starting = true;
            foreach (itemType itemType in itemList)
            {
               
                if (starting == false)
                {
                    result += ",";
                }
                result += itemType.name;
                starting =false;
            }
            result += End;
            //generate enum
            return result;
        }
         string start = "using System;\r\nusing System.Collections.Generic;\r\nusing UnityEngine;\r\nnamespace NBGame.backpack\r\n{\r\n    public class PickableItems\r\n    {\r\n        private static Dictionary<itemsName, itemType> _ItemByName;\r\n        public static Dictionary<itemsName, itemType> ItemByName { get { if (_ItemByName == null) { load(); } return _ItemByName; } set { _ItemByName = value; } }\r\n        public static List<itemType> _Items;\r\n        public static List<itemType> Items { get { if (_Items == null) { loadList(); return _Items; } return _Items; } set { _Items = value; } }\r\n\r\n        \r\n\r\n        public static string json = \"";

         string loadMethod = "\r\n        private static void loadList()\r\n        {\r\n            ItemArrObj itemArrObj = JsonUtility.FromJson<ItemArrObj>(json);\r\n            itemType[] ResultArr = itemArrObj.Itemarr;\r\n            _Items = new List<itemType>();\r\n            foreach (itemType itemType in ResultArr)\r\n            {\r\n                _Items.Add(itemType);\r\n            }\r\n        }\r\n        private static void load()\r\n        {\r\n            ItemArrObj itemArrObj = JsonUtility.FromJson<ItemArrObj>(json);\r\n            itemType[] ResultArr = itemArrObj.Itemarr;\r\n            _ItemByName = new Dictionary<itemsName, itemType>();\r\n            foreach (itemType itemType in ResultArr)\r\n            {\r\n                _ItemByName.Add((itemsName)Enum.Parse(typeof(itemsName), itemType.name) , itemType);\r\n            }\r\n        }";
        string EnumStart = "\r\npublic enum itemsName\r\n        {";
        string End = "}\r\n    }\r\n}";
        #endregion
    }
}