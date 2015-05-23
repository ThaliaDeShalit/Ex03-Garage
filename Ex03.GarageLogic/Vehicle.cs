using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        protected string m_Model;
        protected string m_LicenceNumber;
        protected float m_PercentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;

        public virtual Vehicle(string i_Model, string i_LicenceNumber)
        {
            m_Model = i_Model;
            m_LicenceNumber = i_LicenceNumber;
        }

        public virtual void InitializeWheels(string i_ManufcatorName, float i_MaxWheelAirPressure, int i_AmountOfWheels)
        {
            Wheel tempWheel = new Wheel(i_ManufcatorName, i_MaxWheelAirPressure);

            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_Wheels.Add(tempWheel);
            }
        }
    }
}
