﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskManagement.Models
{
    public partial class Task : ObservableObject
    {
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _title = string.Empty;
        [ObservableProperty]
        private string _description = string.Empty;
        [ObservableProperty]
        private bool _isChecked;
        [ObservableProperty]
        public DateTime _expiryDate;
    }
}
