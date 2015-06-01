using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(Exception i_InnerExcpetion, float i_MaxValue, float i_MinValue) : base("Value out of range", i_InnerExcpetion)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(string i_ErrorMessage) : base(i_ErrorMessage)
        {
            return;
        }

        public string Message
        {
            get
            {
                return string.Format("Value must be between {0} and {1}", m_MinValue, m_MaxValue);
            }
        }
    }
}
