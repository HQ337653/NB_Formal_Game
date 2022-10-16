namespace NBGame.saveSystem
{
    // anything that need to save/load data have to implement this interface
    public interface WorldLoader
    {
        public void LoadGame(WorldData data);

        public void saveGame(ref WorldData data);
    }
}
