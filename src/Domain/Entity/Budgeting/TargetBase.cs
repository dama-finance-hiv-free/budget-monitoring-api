﻿using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting
{
    public class TargetBase : IIdentifiableEntity
    {
        public string Tenant { get; set; }
        public string Outlay { get; set; }
        public string CopYear { get; set; }
        public string Project { get; set; }
        public string Component { get; set; }
        public string Region { get; set; }
        public double Target { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
