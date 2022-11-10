namespace NBGame.saveSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    //This class it to load and save game , if anything wrong about loading/saving happend, delete all gameData in your persistentdatapath
    // https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
    public class GameSaveLoader : MonoBehaviour
    {
        private GameData data;
        //like the pointer and the processor of saved game data
        private SaveDataHandler Handler;
        //file will be named FileName-1.txt exc.
        [SerializeField] string FileName;


        //all things in charge of loading the game
        private List<EnemyLoader> EnemyObjs;
        private List<NpcLoader> NpcObjs;
        private List<CharacterLoader> CharaObjs;
        private List<WorldLoader> WorldObjs;
        static GameSaveLoader instance;
        private List<playerInfoLoader> playerInfoObjs;

        private void Awake()
        {
            FileName = "Gamedata";
            instance = this;
            playerInfo[] arr = new playerInfo[3];
            arr[0] = new playerInfo();
            arr[1] = new playerInfo();
            arr[2] = new playerInfo();
        }

        //load the game in Application.persistentDataPath+ Gamedata- + i + .txt
        //set the handerler
        public static void Load(int i)
        {
            //GameSaveLoader instance = FindObjectOfType<GameSaveLoader>();
            instance.loadFromSave(i);
        }
        //save the game based on the current handler
        public static void Save()
        {
            //GameSaveLoader instance = FindObjectOfType<GameSaveLoader>();
            instance.saveGame();
        }


        private void loadFromSave(int i)
        {
            Handler = new SaveDataHandler(Application.persistentDataPath, FileName + "-" + i + ".txt");
            data = Handler.load();
            loadGame();
        }

        private void loadGame()
        {
            WorldObjs = getAllWorldData();
            EnemyObjs = getAllEnemy();
            CharaObjs = getAllCharacter();
            NpcObjs = getAllNpc();
            playerInfoObjs = getAllPlayerInfo();

            data = Handler.load();
            if (data == null)
            {
                data = new GameData();
            }

            foreach (EnemyLoader obj in EnemyObjs)
            {
                obj.LoadGame(data.EnemyData);
            }
            foreach (NpcLoader obj in NpcObjs)
            {
                obj.LoadGame(data.NpcData);
            }
            foreach (CharacterLoader obj in CharaObjs)
            {
               // obj.LoadGame(data.CharacterData);
            }
            foreach (WorldLoader obj in WorldObjs)
            {
                obj.LoadGame(data.WorldData);
            }
            foreach (playerInfoLoader obj in playerInfoObjs)
            {
                obj.LoadGame(data.playerInfo);
            }
        }

        private void saveGame()
        {
            WorldObjs = getAllWorldData();
            EnemyObjs = getAllEnemy();
            CharaObjs = getAllCharacter();
            NpcObjs = getAllNpc();
            playerInfoObjs = getAllPlayerInfo();
            data = new GameData();
            foreach (EnemyLoader obj in EnemyObjs)
            {
                obj.saveGame(ref data.EnemyData);
            }
            foreach (NpcLoader obj in NpcObjs)
            {
                obj.saveGame(ref data.NpcData);
            }
            foreach (CharacterLoader obj in CharaObjs)
            {
                obj.saveGame(ref data.CharacterData);
            }
            foreach (WorldLoader obj in WorldObjs)
            {
                obj.saveGame(ref data.WorldData);
            }
            foreach (playerInfoLoader obj in playerInfoObjs)
            {
                obj.saveGame(ref data.playerInfo);
            }
            Handler.save(data);

        }


        #region findAllLoadableThings in scene
        private List<WorldLoader> getAllWorldData()
        {
            IEnumerable<WorldLoader> Obj = FindObjectsOfType<MonoBehaviour>().OfType<WorldLoader>();
            return new List<WorldLoader>(Obj);
        }
        private List<CharacterLoader> getAllCharacter()
        {
            IEnumerable<CharacterLoader> Obj = FindObjectsOfType<MonoBehaviour>().OfType<CharacterLoader>();
            return new List<CharacterLoader>(Obj);
        }
        private List<EnemyLoader> getAllEnemy()
        {
            IEnumerable<EnemyLoader> Obj = FindObjectsOfType<MonoBehaviour>().OfType<EnemyLoader>();
            return new List<EnemyLoader>(Obj);
        }

        private List<NpcLoader> getAllNpc()
        {
            IEnumerable<NpcLoader> Obj = FindObjectsOfType<MonoBehaviour>().OfType<NpcLoader>();
            return new List<NpcLoader>(Obj);
        }
        private List<playerInfoLoader> getAllPlayerInfo()
        {
            IEnumerable<playerInfoLoader> Obj = FindObjectsOfType<MonoBehaviour>().OfType<playerInfoLoader>();
            
            return new List<playerInfoLoader>(Obj);
            
        }


        #endregion
    }
}