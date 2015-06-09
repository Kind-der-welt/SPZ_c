using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;

namespace Course_proj
{
    public class TemperatureCheck
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }

        public static List<TemperatureCheck> Temperatures
        {
            get
            {
                List<TemperatureCheck> result = new List<TemperatureCheck>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");

                var enumerator = searcher.Get().GetEnumerator();

                while( enumerator.MoveNext() )
                {
                    var current = enumerator.Current;

                    Double temp = Convert.ToDouble( current[ "CurrentTemperature" ].ToString() );
                    temp = (temp / 10) - 273.15;
                    result.Add(new TemperatureCheck { CurrentValue = temp, InstanceName = current["InstanceName"].ToString() });
                }

                return result;
            }
        }
    }
}
