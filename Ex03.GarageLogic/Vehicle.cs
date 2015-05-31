using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicencePlate;
        protected float m_PercentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected PowerSource m_PowerSource;

        public Vehicle(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource)
        {
            m_Model = i_Model;
            m_LicencePlate = i_LicenceNumber;
            m_PowerSource = i_PowerSource;
            m_PercentageOfEnergyLeft = i_PowerSource.CurrentPowerSourceCapacity / i_PowerSource.MaximumPowerSourceCapacity;
        }

        public virtual void InitializeWheels(string i_ManufcatorName, float i_MaxWheelAirPressure, float i_CurrentAirPressure, int i_AmountOfWheels)
        {
            Wheel tempWheel = new Wheel(i_ManufcatorName, i_MaxWheelAirPressure, i_CurrentAirPressure);

            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_Wheels.Add(tempWheel);
            }
        }

        public string LicenceNumber
        {
            get
            {
                return m_LicencePlate;
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

        public string ToString()
        {
            string str = string.Format(
@"Vehicle:
Model name - {0}
Licence plate - {1}

Wheel:
Manufctor name - {3}
Current air pressure - {4} out of {5}

Power Source:
Current percentage of power in power source - {2}
{6}", m_Model, m_LicencePlate, m_PercentageOfEnergyLeft, m_Wheels[0].ManufctorName, m_Wheels[0].CurrentAirPressure, m_Wheels[0].MaxAirPressure, m_PowerSource.ToString());

            return str;
        }
    }
}
