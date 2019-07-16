namespace Hololens.Obeya.Core.ViewModels
{
    using System;
    using System.Linq;
    using Base;
    using Models;
    using Services.DataService;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    public class TasksViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private ObservableCollection<TaskModel> tasks;
        private ObservableCollection<TaskModel> todoTasks;
        private ObservableCollection<TaskModel> wipTasks;
        private ObservableCollection<TaskModel> doneTasks;
        private TaskModel selectedTask;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dataService">service with fake data</param>
        public TasksViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            tasks = this.dataService.GetTasksItemsData();
        }

        public ObservableCollection<TaskModel> Tasks
        {
            get { return this.tasks; }
            set
            {
                this.tasks = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<TaskModel> TodoTasks
        {
            get { return this.todoTasks; }
            set
            {
                this.todoTasks = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<TaskModel> WipTasks
        {
            get { return this.wipTasks; }
            set
            {
                this.wipTasks = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<TaskModel> DoneTasks
        {
            get { return this.doneTasks; }
            set
            {
                this.doneTasks = value;
                RaisePropertyChanged();
            }
        }

        public TaskModel SelectedTask
        {
            get { return this.selectedTask; }
            set
            {
                this.selectedTask = value;
                RaisePropertyChanged();
            }
        }

        public void AddNewTask(string description)
        {
            var task = dataService.CreateNewTask(description);
            Tasks.Add(task);
            var tasksBackUp = new List<TaskModel>();

            InitializeTasks();
        }

        public void InitializeTasks()
        {
            TodoTasks = null;
            WipTasks = null;
            DoneTasks = null;
            TodoTasks = new ObservableCollection<TaskModel>(tasks.Where(t => t.Status == Enums.StatusEnum.TODO).ToList());
            WipTasks = new ObservableCollection<TaskModel>(tasks.Where(t => t.Status == Enums.StatusEnum.WIP).ToList());
            DoneTasks = new ObservableCollection<TaskModel>(tasks.Where(t => t.Status == Enums.StatusEnum.DONE).ToList());
        }
    }
}
