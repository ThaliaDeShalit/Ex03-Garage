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

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            // If attempting to set current capacity to a value too large, throw exception
            // The Wheel cannot be over-filled
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Value out of range");
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }

        public string ManufctorName
        {
            get
            {
                return m_ManufctorName;
            }
            set
            {
                // If the string is empty throw the proper exception. The wheel must have a manufacturer name
                if (value == string.Empty)
                {
                    throw new FormatException("Wheel manufctor name can not be null");
                }
                else
                {
                    m_ManufctorName = value;
                }
            }
        }

        public void SetCurrentAirPressure(string i_Input)
        {
            float airPressureInFloat;
            if (float.TryParse(i_Input, out airPressureInFloat))
            {
                if (airPressureInFloat > m_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }
                else if (airPressureInFloat < 0)
                {
                    // If the input is negative, throw the proper exception. Air pressure must be positive
                    throw new FormatException("Current air pressure can not be below 0");
                }
                else
                {
                    CurrentAirPressure = airPressureInFloat;
                }
            }
            else
            {
                // If the input is not a number, throw the proper exception
                throw new FormatException("Current air pressure must consist of digits");
            }
        }
    }
}
