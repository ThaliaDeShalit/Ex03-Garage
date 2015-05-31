using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleInfo
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleInfo(string i_VehicleOwnerName, string i_VehicleOwnerNumber, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerNumber = i_VehicleOwnerNumber;
            m_VehicleStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public string ToString()
        {
            string str = string.Format(
@"General vehicle info:
Vehicle owner - {0}
Vehicle status - {1}

{2}", m_VehicleOwnerName, m_VehicleStatus, m_Vehicle.ToString());

            return str;
        }
    }

    public enum eVehicleStatus {
        InProgress = 1,
        Fixed,
        Paid
    }
}
