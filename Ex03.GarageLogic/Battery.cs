using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Battery : PowerSource
    {
        public Battery(float i_MaxChargeInHours, float i_CurrentChargeInHours)
        {
            m_MaximumCapacity = i_MaxChargeInHours;
            m_CurrentCapacity = i_CurrentChargeInHours;
        }

        public void Charge(float i_NumOfHoursToAdd)
        {
            FillPowerSource(i_NumOfHoursToAdd);
        }

        public override string ToString()
        {
            return "Power source type - battery";
        }
    }
}
