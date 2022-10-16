namespace NBGame.quest
{
    public class questRequirement
    {
       public string description;
        private bool _finished=false;
        public bool finished { get { return _finished; }set { _finished = value; requirementMeeted?.Invoke(_finished); } }
        public delegate void d(bool active);
        public d requirementMeeted;

    }
}
