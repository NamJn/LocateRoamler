using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocateRoamler.Core.Models
{
    public class LocationResultModel
    {
        /// <summary>
        /// Location name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location distance.
        /// </summary>
        public double Distance { get; set; }
    }
}
