using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleInfo> m_Vehicles;

        public void InsertNewVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleType i_VehicleType, Dictionary<string, object> i_VehicleProporties)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_VehicleProporties);
            VehicleInfo newVehicle = new VehicleInfo(i_OwnerName, i_OwnerNumber, eVehicleStatus.InProgress, vehicle);
        }

        public bool CheckIfExists(string i_LicencePlate)
        {
            bool exists = false;

            if (m_Vehicles.ContainsKey(i_LicencePlate))
            {
                exists = true;
                m_Vehicles[i_LicencePlate].VehicleStatus = eVehicleStatus.InProgress;
            }

            return exists;
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

            if (!vehicleToFuel.isFueled())
            {
                throw new ArgumentException();
            }
            else
            {
                FuelTank fuelTank = (FuelTank)vehicleToFuel.PowerSource;

                if (fuelTank.FuelType == i_FuelType) {
                    fuelTank.Fuel(i_AmountOfFuel, i_FuelType);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void ChargeVehicle(string i_LicencePlate, float i_NumOfMinuToCharge)
        {
            Vehicle vehicleToCharge = m_Vehicles[i_LicencePlate].Vehicle;

            if (!vehicleToCharge.isElectric())
            {
                throw new ArgumentException();
            }
            else
            {
                ((Battery)vehicleToCharge.PowerSource).Charge(i_NumOfMinuToCharge);
            }
        }
    }
}
