// template for saved data, please use json serilizable data structure to store data
//put all things need to store in the subData(like WorldData)
namespace NBGame.saveSystem
{
    public class GameData
    {
        public playerInfo playerInfo;
        public WorldData WorldData;
        public NpcData NpcData;

        public EnemyData EnemyData;
        public CharacterData CharacterData;

        public GameData()
        {

            WorldData = new WorldData();
            NpcData = new NpcData();
            CharacterData = new CharacterData();
            EnemyData = new EnemyData();
            playerInfo = new playerInfo();
        }
    }
}