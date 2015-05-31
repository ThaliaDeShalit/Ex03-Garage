using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Battery : PowerSource
    {
        public Battery(float i_MaxChargeInHours)
        {
            m_MaximumCapacity = i_MaxChargeInHours;
        }

        public void Charge(float i_NumOfHoursToAdd)
        {
            FillPowerSource(i_NumOfHoursToAdd);
        }

        public string ToString()
        {
            return "Power source type - battery";
        }
    }
}
