using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Battery
    {
        private float m_ChargeLeftInHours;
        private float m_MaxChargeInHours;

        public Battery(float i_MaxChargeInHours)
        {
            m_MaxChargeInHours = i_MaxChargeInHours;
        }

        public float ChargeLeftInHours
        {
            set
            {
                m_ChargeLeftInHours = value;
            }
            get
            {
                return m_ChargeLeftInHours;
            }
        }

        public float MaxChargeInHours
        {
            get
            {
                return m_MaxChargeInHours;
            }
        }

        public void Charge(float i_NumOfChargeHoursToAdd)
        {
            if (m_ChargeLeftInHours + i_NumOfChargeHoursToAdd > m_MaxChargeInHours)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_ChargeLeftInHours += i_NumOfChargeHoursToAdd;
            }
        }
    }
}
