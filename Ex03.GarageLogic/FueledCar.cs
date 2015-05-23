using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        private const float K_FuelTankMaxFuelAmount = 35f;
        private const eFuelType k_FuelType = eFuelType.Octan96;
        
        private FuelTank m_FuelTank;

        public FueledCar(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, eCarColor i_CarColor, eNumOfCarDoors i_NumOfCarDoors)
            : base(i_Model, i_LicenceNumber, i_WheelManufactorName, i_CarColor, i_NumOfCarDoors)
        {
            m_FuelTank = new FuelTank(k_FuelType, K_FuelTankMaxFuelAmount);
        }
    }
}
