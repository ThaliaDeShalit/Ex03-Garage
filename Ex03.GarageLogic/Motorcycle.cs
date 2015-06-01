using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int k_AmountOfWheels = 2;
        private readonly float r_MaxAirPressure;

        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        public Motorcycle(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource, string i_WheelManufactorName, float i_MaxAirPressure, float i_CurrentAirPressure, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_Model, i_LicenceNumber, i_PowerSource)
        {
            InitializeWheels(i_WheelManufactorName, r_MaxAirPressure, i_CurrentAirPressure, k_AmountOfWheels);
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ToString()
        {
            string str = string.Format(
@"{0}

Motorcycle properties:
Licence type - {1}
Engine volume - {2}", base.ToString(), m_LicenceType, m_EngineVolume.ToString());

            return str;
        }

        protected enum eProperties
        {
            LicenceType = (Enum.GetValues(typeof(Vehicle.eProperties)).Length + 1),
            EngineVolume
        }
    }

    public enum eLicenceType
    {
        A = 1,
        A2,
        AB,
        B1
    }
}
