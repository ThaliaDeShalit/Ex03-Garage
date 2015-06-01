using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal const float k_MaxWheelAirPressure = 31;
        private const int k_AmountOfWheels = 4;

        private eCarColor m_CarColor;
        private eAmountOfDoors m_NumOfCarDoors;

        internal Car(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource, string i_WheelManufactorName, float i_CurrentAirPressure, eCarColor i_CarColor, eAmountOfDoors i_NumOfCarDoors)
            : base(i_Model, i_LicenceNumber, i_PowerSource)
        {
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, i_CurrentAirPressure, k_AmountOfWheels);
            m_CarColor = i_CarColor;
            m_NumOfCarDoors = i_NumOfCarDoors;
        }

        internal string ToString()
        {
            string str = string.Format(
@"{0}

Car properties:
Car color - {1}
Number of doors - {2}", base.ToString(), m_CarColor, m_NumOfCarDoors);

            return str;
        }

        protected enum eProperties
        {
            CarColor = (Enum.GetValues(typeof(Vehicle.eProperties)).Length + 1),
            AmountOfDoors
        }
    }

    internal enum eCarColor
    {
        Green = 1,
        Red,
        White,
        Black
    }

    internal enum eAmountOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
