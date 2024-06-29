using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace TaskManagement.ViewModels.Tasks
{
    public partial class AddOrUpdateTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _isCheckedIcon = string.Empty;
        [ObservableProperty]
        private string _isCheckedText = string.Empty;
        private DateTime _selectedDate;
        [ObservableProperty]
        private string _selectedDateBackgroudColor;
        [ObservableProperty]
        private string _selectedDateText;
        [ObservableProperty]
        private Models.Task _task = new Models.Task();

        public AddOrUpdateTaskViewModel()
        {
            SetTaskStatus();
        }

        #region Commands
        public ICommand ExchangeStatusCommand => new RelayCommand(ExchangeStatus);
        public ICommand MainCommand => new RelayCommand(MainAction);
        #endregion

        #region Methods
        private bool DateValidator(DateTime startTime, DateTime endTime)
        {
            int result = DateTime.Compare(startTime, endTime);
            if (result < 0)
                return true;

            else if (result == 0)
                return false;
            else
                return false;
        }
        private void ExchangeStatus()
        {
            Task.IsChecked = !Task.IsChecked;
            SetTaskStatus();
        }
        private void SetTaskStatus()
        {
            IsCheckedIcon = Task.IsChecked ? "CheckboxMarkedCircleOutline" : "CheckboxBlankCircleOutline";
            IsCheckedText = Task.IsChecked ? "MARCAR COMO IMCOMPLETA" : "MARCAR COMO COMPLETA";
        }
        public virtual void MainAction()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public DateTime SelectedDate 
        { 
            get => _selectedDate; 
            set 
            {
                SetProperty(ref _selectedDate, value);
                SelectedDateText = value.ToString("dd MMMM, yyyy");
                var result = DateValidator(DateTime.Now, value);
                SelectedDateBackgroudColor = result ? "#BBF7D0" : "#FECACA";
                Task.ExpiryDate = value;
            }
        }
        #endregion
    }
}
