using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Battery : PowerSource
    {
        internal Battery(float i_MaxChargeInHours, float i_CurrentChargeInHours)
        {
            m_MaximumCapacity = i_MaxChargeInHours;
            m_CurrentCapacity = i_CurrentChargeInHours;
        }

        // TODO change number of charge to minutes instead of hours??
        internal void Charge(float i_NumOfHoursToAdd)
        {
            FillPowerSource(i_NumOfHoursToAdd);
        }

        internal override string ToString()
        {
            return "Power source type - battery";
        }
    }
}
