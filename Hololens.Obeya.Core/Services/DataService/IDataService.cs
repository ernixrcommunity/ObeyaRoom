namespace Hololens.Obeya.Core.Services.DataService
{
    using Hololens.Obeya.Core.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Contract definition for fake data service.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Get workforce availavility screen data.
        /// </summary>
        /// <returns>Main screen business unit with children</returns>
        BusinessUnitModel GetWorkforceData();

        /// <summary>
        /// Get Strategy items screen data.
        /// </summary>
        /// <returns>List of strategy items.</returns>
        ObservableCollection<StrategyItemModel> GetStrategyItemsData(bool accomplished = false);

        /// <summary>
        /// Get Management tasks screen data.
        /// </summary>
        /// <returns>List of tasks.</returns>
        ObservableCollection<TaskModel> GetTasksItemsData();

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="description">Task description</param>
        /// <returns>New task.</returns>
        TaskModel CreateNewTask(string description);

        /// <summary>
        /// Get customer acquisition screen data.
        /// </summary>
        /// <returns>Customer data.</returns>
        CustomerAcquisitionModel GetCustomerAcquisitionData();
    }
}
