// anything that need to save/load data have to implement this interface
public interface EnemyLoader 
{
    public void LoadGame(EnemyData data);

    public void saveGame(ref EnemyData data);
}
