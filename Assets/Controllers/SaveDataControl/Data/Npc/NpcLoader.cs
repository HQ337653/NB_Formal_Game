// anything that need to save/load data have to implement this interface
public interface NpcLoader 
{
    public void LoadGame(NpcData data);

    public void saveGame(ref NpcData data);
}
