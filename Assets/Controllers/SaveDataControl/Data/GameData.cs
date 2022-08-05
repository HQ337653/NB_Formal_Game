// template for saved data, please use json serilizable data structure to store data
//put all things need to store in the subData(like WorldData)
public class GameData 
{
    public WorldData WorldData;
    public NpcData NpcData;
    public CharacterData CharacterData;
    public EnemyData EnemyData;

    public GameData()
    {
        WorldData = new WorldData();
        NpcData = new NpcData();
        CharacterData = new CharacterData();
        EnemyData = new EnemyData();
    }
}
