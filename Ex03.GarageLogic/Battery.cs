using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Battery : PowerSource
    {
        public Battery(float i_MaxChargeInHours)
        {
            m_MaximumCapacity = i_MaxChargeInHours;
        }

        // charges the battery with hours
        internal void Charge(float i_NumOfHoursToAdd)
        {
            FillPowerSource(i_NumOfHoursToAdd);
        }

        public override string ToString()
        {
            return "Power source type - battery";
        }
    }
}
