namespace NBGame.saveSystem
{
    // anything that need to save/load data have to implement this interface
    public interface CharacterLoader
    {
        public void LoadGame(CharacterData data);

        public void saveGame(ref CharacterData data);
    }
}