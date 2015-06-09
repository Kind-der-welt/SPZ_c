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
                foreach (ManagementObject obj in searcher.Get())
                {
                    Double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                    temp = (temp - 2732) / 10.0;
                    result.Add(new TemperatureCheck { CurrentValue = temp, InstanceName = obj["InstanceName"].ToString() });
                }
                return result;
                // Console.WriteLine(searcher); 
            }
            //
        }
    }
}
