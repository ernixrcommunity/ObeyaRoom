namespace Hololens.Obeya.Core.Services.DataService
{
    using Enums;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Contract implementation for fake data service.
    /// </summary>
    public class DataService : IDataService
    {
        private readonly Random random;

        public DataService()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// <see cref="IDataService"/>
        /// </summary>
        /// <returns><see cref="IDataService"/></returns>
        public CustomerAcquisitionModel GetCustomerAcquisitionData()
        {
            Random rand = new Random(DateTime.Now.Second);
            CustomerAcquisitionModel items = new CustomerAcquisitionModel();
            items.CurrentOffers = new List<CurrentOfferModel>();
            items.KeyAccounts = new List<string>() { "Roche", "HP", "Microsoft", "Google", "Apple", "Scorpio" };
            items.Opportunities = new List<string>() { "Opportunity 1", "Opportunity 2", "Opportunity 3" };
            items.Requests = new List<string>() { "Request 1", "Request 2", "Request 3" };

            for(int i = 0; i < 15; i++)
            {
                var number = rand.Next(1, 4);
                items.CurrentOffers.Add(new CurrentOfferModel()
                {
                    CompanyName = $"Company {i}",
                    Status = number == 1 ? OfferStatus.ContractSigned : number == 2 ? OfferStatus.Negotiation : OfferStatus.NoContract,
                });
            }

            return items;
        }

        /// <summary>
        /// <see cref="IDataService"/>
        /// </summary>
        /// <returns><see cref="IDataService"/></returns>
        public ObservableCollection<StrategyItemModel> GetStrategyItemsData(bool accomplished = false)
        {
            ObservableCollection<StrategyItemModel> items = new ObservableCollection<StrategyItemModel>();
            var amountItems = random.Next(20, 80) / 10;

            for (int i = 0; i < amountItems; i++)
            {
                items.Add(new StrategyItemModel()
                {
                    Title = $"Strategy Item {i + 1}",
                    Status = accomplished ? 1 : random.NextDouble(),
                    LongStatusDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    WhatIncludes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    People = new List<string>()
                    {
                        "Matt Larson", "Gerard Esparducer", "Alfons Martínez", "Jazz Kan", "Marcos Cobeña"
                    }
                });
            }

            return items;
        }

        /// <summary>
        /// <see cref="IDataService"/>
        /// </summary>
        /// <returns><see cref="IDataService"/></returns>
        public ObservableCollection<TaskModel> GetTasksItemsData()
        {
            ObservableCollection<TaskModel> items = new ObservableCollection<TaskModel>();
            Random rand = new Random(DateTime.Now.Second);

            for (int i = 1; i < 15; i++)
            {
                var task = CreateNewTask(
                    title: $"Task {i}",
                    shortDescription: $"Short task description {i}",
                    longDescription: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    status: rand.Next(1, 4));
                task.DueDate = DateTime.Now.Add(new TimeSpan(i, 0, 0, 0));
                items.Add(task);
            }

            return items;
        }

        private TaskModel CreateNewTask(string title, string shortDescription, string longDescription, int status)
        {
            return new TaskModel()
            {
                Title = title,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                Status = status == 1 ? StatusEnum.TODO : status == 2 ? StatusEnum.WIP : StatusEnum.DONE,
                DueDate = DateTime.Now.AddDays(7),
                People = new List<string>()
                    {
                        "Matt Larson", "Gerard Esparducer", "Alfons Martínez", "Jazz Kan", "Marcos Cobeña"
                    }
            };
        }

        public TaskModel CreateNewTask(string description)
        {
            return CreateNewTask(
                title: description.Length > 10 ? description.Substring(0, 7) + "..." : description,
                shortDescription: description,
                longDescription: description,
                status: 1);
        }

        /// <summary>
        /// <see cref="IDataService"/> 
        /// </summary>
        /// <returns><see cref="IDataService"/> </returns>
        public BusinessUnitModel GetWorkforceData()
        {
            Random rand = new Random(DateTime.Now.Second);

            BusinessUnitModel items = GenerateBusinessUnit("", "", rand.NextDouble());

            for (int i = 0; i < 10; i++)
            {
                var newBU = GenerateBusinessUnit($"Business Unit {i}", $"BU {i}", rand.NextDouble());

                Random numUnitsRandom = new Random(i);
                var numUnits = numUnitsRandom.Next(1, 5);
                for (int j = 0; j < numUnits; j++)
                {
                    var newSubBU = GenerateBusinessUnit($"Business Unit {i}", $"BU {i} - {j}", newBU.Availability);
                    newBU.ChildrenBUs.Add(newSubBU);
                }
                items.ChildrenBUs.Add(newBU);
            }

            return items;
        }

        private BusinessUnitModel GenerateBusinessUnit(string title, string shortName, double availability)
        {
            var newBU = new BusinessUnitModel()
            {
                Title = title,
                ShortName = shortName,
                Availability = availability
            };

            int min = newBU.Availability < 0.3 ? 20 : newBU.Availability > 0.3 && newBU.Availability < 0.7 ? 55 : 85;
            int max = newBU.Availability < 0.3 ? 30 : newBU.Availability > 0.3 && newBU.Availability < 0.7 ? 65 : 95;
            Random hRand = new Random(max);
            newBU.AvailabilityHistoric = new List<GenericDateValueModel>();
            for (int j = -12; j < -1; j++)
            {
                newBU.AvailabilityHistoric.Add(new GenericDateValueModel(DateTime.Now.AddMonths(j), hRand.Next(min, max)));
            }
            newBU.ChildrenBUs = new List<BusinessUnitModel>();
            return newBU;
        }
    }
}
