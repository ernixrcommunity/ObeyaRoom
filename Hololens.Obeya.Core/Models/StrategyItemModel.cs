namespace Hololens.Obeya.Core.Models
{
    using System.Collections.Generic;

    public class StrategyItemModel
    {
        public string Title { get; set; }

        public double Status { get; set; }

        public string WhatIncludes { get; set; }

        public string LongStatusDescription { get; set; }

        public IList<string> People { get; set; }
    }
}
