using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        private const float K_FuelTankMaxFuelAmount = 35f;
        private const eFuelType k_FuelType = eFuelType.Octan96;
        
        public FueledCar(string i_Model, string i_LicencePlate, string i_WheelManufactorName, eCarColor i_CarColor, eNumOfCarDoors i_NumOfCarDoors)
            : base(i_Model, i_LicencePlate, i_WheelManufactorName, i_CarColor, i_NumOfCarDoors)
        {
            m_PowerSource = new FuelTank(k_FuelType, K_FuelTankMaxFuelAmount);
        }

        public eFuelType FuelType
        {
            get
            {
                return k_FuelType;
            }
        }
    }
}
