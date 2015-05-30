using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicenceNumber;
        protected float m_PercentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected PowerSource m_PowerSource;

        public virtual Vehicle(string i_Model, string i_LicenceNumber)
        {
            m_Model = i_Model;
            m_LicenceNumber = i_LicenceNumber;
        }

        // TODO:
        public virtual void InitializeWheels(string i_ManufcatorName, float i_MaxWheelAirPressure, float i_CurrentWheelPressure, int i_AmountOfWheels)
        {
            Wheel tempWheel = new Wheel(i_ManufcatorName, i_MaxWheelAirPressure);

            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_Wheels.Add(tempWheel);
            }
        }

        public string LicenceNumber
        {
            get
            {
                return m_LicenceNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                return m_PowerSource;
            }
        }

        public bool isFueled()
        {
            bool v_Fuel = false;

            if (m_PowerSource is FuelTank)
            {
                v_Fuel = true;
            }

            return v_Fuel;
        }

        public bool isElectric()
        {
            bool v_Electric = false;

            if (m_PowerSource is Battery)
            {
                v_Electric = true;
            }

            return v_Electric;
        }
    }
}
