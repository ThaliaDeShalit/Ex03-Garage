using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelTank
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public FuelTank(eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelAmount = i_MaxFuelAmount;
        }

        public float CurrentFuelAmount
        {
            set
            {
                m_CurrentFuelAmount = value;
            }
            get
            {
                return m_CurrentFuelAmount;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return m_MaxFuelAmount;
            }
        }

        public void Fuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException();
            }
            else if (i_AmountOfFuelToAdd + m_CurrentFuelAmount > m_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(m_MaxFuelAmount - m_CurrentFuelAmount, 0f);
            }
            else
            {
                m_CurrentFuelAmount += i_AmountOfFuelToAdd;
            }
        } 
    }
}
