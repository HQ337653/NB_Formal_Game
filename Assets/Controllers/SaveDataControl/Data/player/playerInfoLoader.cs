namespace NBGame.saveSystem
{
    public interface playerInfoLoader
    {
        public void LoadGame(playerInfo data);

        public void saveGame(ref playerInfo data);
    }
}