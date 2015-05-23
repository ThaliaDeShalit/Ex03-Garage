using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        protected const float k_MaxWheelAirPressue = 31;

        protected eCarColor m_CarColor;
        protected eNumOfCarDoors m_NumOfCarDoors;

        public Car(string i_Model, string i_LicenceNumber, string i_WheelManufactorName, eCarColor i_CarColor, eNumOfCarDoors i_NumOfCarDoors) : base(i_Model, i_LicenceNumber)
        {
            createWheels(i_WheelManufactorName, ref base.m_Wheels);
            m_CarColor = i_CarColor;
            m_NumOfCarDoors = i_NumOfCarDoors;
        }

        private void createWheels(string i_ManufcatorName, ref List<Wheel> i_Wheels) {
            Wheel tempWheel = new Wheel(i_ManufcatorName, k_MaxWheelAirPressue);

            for(int i = 0; i < 4; i++) {
                i_Wheels.Add(tempWheel);
            }
        }
    }

    enum eCarColor
    {
        Green,
        Red,
        White,
        Black
    }

    enum eNumOfCarDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
