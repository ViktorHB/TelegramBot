using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SquaredCircle_bot
{
    /// <summary>
    /// Base class for view models which implements INotifyPropertyChanged
    /// </summary>
    public class ViewModelBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}