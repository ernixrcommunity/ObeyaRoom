namespace Hololens.Obeya.Core.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Windows.UI.Xaml.Controls;

    public class TaskModel : Control, INotifyPropertyChanged
    {
        private StatusEnum status;
        private bool isNearToDueDate;

        public TaskModel()
        {
            this.DefaultStyleKey = typeof(TaskModel);
        }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public StatusEnum Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }

        public DateTime DueDate { get; set; }

        public bool IsNearToDueDate {
            get { return isNearToDueDate; }
            set
            {
                this.isNearToDueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsNearToDueDate"));
            }
        }

        public IList<string> People { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
