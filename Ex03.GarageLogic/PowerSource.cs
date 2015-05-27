using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class PowerSource
    {
        protected float m_MaximumCapacity;
        protected float m_CurrentCapacity;

        public float CurrentPowerSourceCapacity
        {
            set
            {
                if (value > m_MaximumCapacity)
                {
                    throw new ValueOutOfRangeException();
                }
                else
                {
                    m_CurrentCapacity = value;
                }
            }
            get
            {
                return m_CurrentCapacity;
            }
        }

        public float MaximumPowerSourceCapacity
        {
            get
            {
                return m_MaximumCapacity;
            }
        }

        public void FillPowerSource(float i_NumOfChargeHoursToAdd)
        {
            if (m_CurrentCapacity + i_NumOfChargeHoursToAdd > m_MaximumCapacity)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_CurrentCapacity += i_NumOfChargeHoursToAdd;
            }
        }
    }
}
