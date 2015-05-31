using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelTank : PowerSource
    {
        private eFuelType m_FuelType;

        public FuelTank(eFuelType i_FuelType, float i_MaxFuelAmount, float i_CurrentFuelAmount)
        {
            m_FuelType = i_FuelType;
            m_MaximumCapacity = i_MaxFuelAmount;
            m_CurrentCapacity = i_CurrentFuelAmount;
        }

        public void Fuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException();
            }
            else
            {
                FillPowerSource(i_AmountOfFuelToAdd);
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public override string ToString()
        {
            string str = string.Format(
@"Power source type - fuel tank
Fuel type - {0}", m_FuelType);

            return str;
        }
    }

    public enum eFuelType
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    
}
