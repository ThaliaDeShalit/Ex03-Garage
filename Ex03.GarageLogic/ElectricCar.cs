using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        private const float k_BatteryMaxChargeInHours = 2.2f;

        public ElectricCar(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumOfCarDoors i_NumOfCarDoors)
            : base(i_Model, i_LicenceNumber, i_WheelManufactorName, i_CurrentAirPressure, i_CarColor, i_NumOfCarDoors)
        {
            m_PowerSource = new Battery(k_BatteryMaxChargeInHours);
        }
    }
}
