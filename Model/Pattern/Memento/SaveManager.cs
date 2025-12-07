using Battle_Clans.Model.Pattern.Singleton;

namespace Battle_Clans.Model.Pattern.Memento
{
    public class SaveManager
    {
        private Stack<GameMemento> _history = new Stack<GameMemento>();

        public void QuickSave()
        {
            var save = GameSession.Instance.SaveState();
            _history.Push(save);
        }

        public void QuickLoad()
        {
            if (_history.Count > 0)
            {
                var save = _history.Peek();
                GameSession.Instance.LoadState(save);
            }
        }

        public bool HasSaves => _history.Count > 0;
    }
}
