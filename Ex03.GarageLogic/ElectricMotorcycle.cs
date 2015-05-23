using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxWheelAirPressure = 31;
        private const float k_BatteryMaxChargeInHours = 1.2f;
        
        private Battery m_Battery;

        public ElectricMotorcycle(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_Model, i_LicenceNumber, i_LicenceType, i_EngineVolume)
        {
            m_Battery = new Battery(k_BatteryMaxChargeInHours);
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, k_AmountOfWheels);
        }
    }
}
