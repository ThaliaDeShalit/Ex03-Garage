using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufctorName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufctorName, float i_MaxAirPressure)
        {
            m_ManufctorName = i_ManufctorName;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure - m_CurrentAirPressure, 0f);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }
    }
}
