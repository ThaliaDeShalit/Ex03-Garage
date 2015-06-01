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

        public Wheel(string i_ManufctorName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            m_ManufctorName = i_ManufctorName;
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException();
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
                    throw new FormatException("Current air pressure can not be below 0");
                }
                else
                {
                    CurrentAirPressure = airPressureInFloat;
                }
            }
            else
            {
                throw new FormatException("Current air pressure must consist of digits");
            }
        }
    }
}
