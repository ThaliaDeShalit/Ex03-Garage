using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_AmountOfWheels = 16;
        private const float k_MaxWheelAirPressure = 25f;
        private const float K_FuelTankMaxFuelAmount = 170f;
        private const eFuelType k_FuelType = eFuelType.Soler;

        private bool m_IsCarryingHazardousMaterials;
        private float m_CurrentCarryWeight;

        private FuelTank m_FuelTank;

        public Truck(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, bool i_IsCarryingHazardousMaterials, float i_CurrentCarryWeight)
            : base(i_Model, i_LicenceNumber)
        {
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, k_AmountOfWheels);

            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_CurrentCarryWeight = i_CurrentCarryWeight;
        }
    }
}
