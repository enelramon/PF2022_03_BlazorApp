namespace PF2022_03_BlazorApp.ViewModels
{

    public interface ICounterViewModel
    {
        void IncrementCount();

        int GetCount();

        event Action? StateChanged;

    }

    public class CounterViewModel : ICounterViewModel
    {
        private int _count;

        public event Action? StateChanged;

        public void IncrementCount()
        {
            _count++;
            TriggerStateChange();
        }

        public int GetCount()
        {
            return _count;
        }

        protected void TriggerStateChange()
        {
            StateChanged?.Invoke();
        }
    }
}
