using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
        protected const float k_MaxWheelAirPressure = 31;
        protected const int k_AmountOfWheels = 4;

        protected eCarColor m_CarColor;
        protected eNumOfCarDoors m_NumOfCarDoors;

        public Car(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, eCarColor i_CarColor, eNumOfCarDoors i_NumOfCarDoors) : base(i_Model, i_LicenceNumber)
        {
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, k_AmountOfWheels);
            m_CarColor = i_CarColor;
            m_NumOfCarDoors = i_NumOfCarDoors;
        }
    }

    public enum eCarColor
    {
        Green,
        Red,
        White,
        Black
    }

    public enum eNumOfCarDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
