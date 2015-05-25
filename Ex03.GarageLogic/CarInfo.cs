using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class CarInfo
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public CarInfo(string i_VehicleOwnerName, string i_VehicleOwnerNumber, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerNumber = i_VehicleOwnerNumber;
            m_VehicleStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }
    }

    enum eVehicleStatus {
        InProgress,
        Fixed,
        Paid
    }
}
