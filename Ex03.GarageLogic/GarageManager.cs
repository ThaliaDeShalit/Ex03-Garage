using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GarageManager
    {
        private Dictionary<string, VehicleInfo> m_Vehicles;

        public bool TryToInsertNewVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleType i_VehicleType, Dictionary<string, string> i_VehicleProporties)
        {
            bool insertWasSuccesfull = true;
            
            string licencePlate = i_VehicleProporties["Licence Plate"];

            if (m_Vehicles.ContainsKey(licencePlate))
            {
                insertWasSuccesfull = false;
                m_Vehicles[licencePlate].VehicleStatus = eVehicleStatus.InProgress;
            } else {
                Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleType);
                VehicleInfo newVehicle = new VehicleInfo(i_OwnerName, i_OwnerNumber, eVehicleStatus.InProgress, vehicle);
            }

            return insertWasSuccesfull;
        }

        public List<string> GetLicencePlates(eVehicleStatus? i_VehicleStatus)
        {
            List<string> licencePlate = new List<string>();
            
            if (i_VehicleStatus == null)
            {
                foreach (VehicleInfo vehicleInfo in m_Vehicles.Values)
                {
                    licencePlate.Add(vehicleInfo.Vehicle.LicenceNumber);
                }
            }
            else
            {
                eVehicleStatus vehicleStatus = (eVehicleStatus)i_VehicleStatus;
                
                foreach (VehicleInfo vehicleInfo in m_Vehicles.Values)
                {
                    if (vehicleInfo.VehicleStatus == vehicleStatus)
                    {
                        licencePlate.Add(vehicleInfo.Vehicle.LicenceNumber);
                    }
                }
            }

            return licencePlate;
        }

        public void ChangeVehicleStatus(string i_LicencePlate, eVehicleStatus i_NewStatus)
        {
            m_Vehicles[i_LicencePlate].VehicleStatus = i_NewStatus;
        }

        public void InflateWheels(string i_LicencePlate)
        {
            foreach(Wheel wheel in m_Vehicles[i_LicencePlate].Vehicle.Wheels) {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void FuelVehicle(string i_LicencePlate, eFuelType i_FuelType, float i_AmountOfFuel)
        {
            Vehicle vehicleToFuel = m_Vehicles[i_LicencePlate].Vehicle;

            Type type = vehicleToFuel.GetType();

            type.
            

            if ((type)vehicleToFuel.FuelType)
            {

            }
        }
    }
}
