using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FueledMotorcycle : Motorcycle
    {
        private const float k_MaxWheelAirPressure = 34f;
        private const float K_FuelTankMaxFuelAmount = 8f;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        private FuelTank m_FuelTank;

        public FueledMotorcycle(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_Model, i_LicenceNumber, i_LicenceType, i_EngineVolume)
        {
            m_FuelTank = new FuelTank(k_FuelType, K_FuelTankMaxFuelAmount);
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, k_AmountOfWheels);
        }
    }
}
