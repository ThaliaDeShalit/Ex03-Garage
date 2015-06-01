using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected int m_NumOfExtraProperties;

        protected string m_Model;
        protected string m_LicencePlate;
        protected float m_PercentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected PowerSource m_PowerSource;

        internal Vehicle(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource)
        {
            m_Model = i_Model;
            m_LicencePlate = i_LicenceNumber;
            m_PowerSource = i_PowerSource;
            m_PercentageOfEnergyLeft = i_PowerSource.CurrentPowerSourceCapacity / i_PowerSource.MaximumPowerSourceCapacity;
        }

        internal Vehicle(PowerSource i_PowerSource);

        internal Vehicle(PowerSource i_PowerSource, float i_MaxAirPressure);

        protected void InitializeWheels(string i_ManufcatorName, float i_MaxWheelAirPressure, float i_CurrentAirPressure, int i_AmountOfWheels)
        {
            m_Wheels = new List<Wheel>();
            Wheel tempWheel = new Wheel(i_ManufcatorName, i_MaxWheelAirPressure, i_CurrentAirPressure);

            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_Wheels.Add(tempWheel);
            }
        }

        protected void SetWheelsMaxAirPressure(float i_MaxAirPressure, int i_AmountOfWheels)
        {
            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        internal string Model
        {
            get
            {
                return m_Model;
            }
            set
            {
                if (value != string.Empty)
                {
                    m_Model = value;
                }
                else
                {
                    throw new FormatException("Model name can not be empty");
                }
            }
        }

        internal string LicencePlate
        {
            get
            {
                return m_LicencePlate;
            }
            set
            {
                bool inputIsValid = true;

                foreach (char character in value)
                {
                    if (!char.IsLetterOrDigit(character))
                    {
                        inputIsValid = false;
                        break;
                    }
        }

                if (inputIsValid)
                {
                    m_LicencePlate = value;
                }
                else
                {
                    throw new FormatException("Invalid licence plate");
                }
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        internal PowerSource PowerSource
        {
            get
            {
                return m_PowerSource;
            }
        }

        internal int NumOfExtraProperties
        {
            get
            {
                return m_NumOfExtraProperties;
            }
        }

        internal bool isFueled()
        {
            bool v_Fuel = false;

            if (m_PowerSource is FuelTank)
            {
                v_Fuel = true;
            }

            return v_Fuel;
        }

        internal bool isElectric()
        {
            bool v_Electric = false;

            if (m_PowerSource is Battery)
            {
                v_Electric = true;
            }

            return v_Electric;
        }

        internal float PercentageOfEnergyLeft
        {
            get
            {
                return m_PercentageOfEnergyLeft;
            }
            set
            {
                m_PercentageOfEnergyLeft = value;
            }
        }

        public override string ToString()
        {
            int percentage = (int)(m_PercentageOfEnergyLeft * 100);
            string str = string.Format(
@"Vehicle:
Model name - {0}
Licence plate - {1}

Wheel:
Manufctor name - {3}
Current air pressure - {4} out of {5}

Power Source:
Current percentage of power in power source - {2}%
{6}", m_Model, m_LicencePlate, percentage, m_Wheels[0].ManufctorName, m_Wheels[0].CurrentAirPressure, m_Wheels[0].MaxAirPressure, m_PowerSource.ToString());

            return str;
        }

        internal abstract Question GetProperty(int i_PropertyNumber);

        internal abstract void SetProperty(int i_PropertyNumber, string i_PropertyValue);

    }
}
