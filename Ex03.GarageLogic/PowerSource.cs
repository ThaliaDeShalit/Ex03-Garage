using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class PowerSource
    {
        protected float m_MaximumCapacity;
        protected float m_CurrentCapacity;

        internal float CurrentPowerSourceCapacity
        {
            set
            {
                // If attempting to set current capacity to a value too large, throw exception
                // The PowerSource cannot be over-filled
                if (value > m_MaximumCapacity)
                {
                    throw new ValueOutOfRangeException("Input invalid - value out of range");
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

        internal float MaximumPowerSourceCapacity
        {
            get
            {
                return m_MaximumCapacity;
            }
        }

        internal void FillPowerSource(float i_AmountOfPowerToAdd)
        {
            // If the PowerSource is attempted to be filled over the maximum allowed
            // capacity, throw the proper exception
            if (m_CurrentCapacity + i_AmountOfPowerToAdd > m_MaximumCapacity)
            {
                throw new ValueOutOfRangeException("Invalid input - value out of range");
            }
            else
            {
                m_CurrentCapacity += i_AmountOfPowerToAdd;
            }
        }

        internal void SetCurrentPowerSourceCapacity(string i_Input)
        {
            float currentCapacityInFloat;
            if (float.TryParse(i_Input, out currentCapacityInFloat))
            {
                if (currentCapacityInFloat > m_MaximumCapacity)
                {
                    throw new ValueOutOfRangeException(0, m_MaximumCapacity);
                }
                else if (currentCapacityInFloat < 0)
                {
                    throw new FormatException("Current power source capcity can not be below 0");
                }
                else
                {
                    CurrentPowerSourceCapacity = currentCapacityInFloat;
                }
            }
            else
            {
                throw new FormatException("Current power source capacity must consist of digits");
            }
        }
    }
}
