using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleInfo> m_Vehicles = new Dictionary<string, VehicleInfo>();

        public void InsertNewVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleType i_VehicleType, Dictionary<eVehiclePropertyType, object> i_VehicleProporties)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_VehicleProporties);
            VehicleInfo newVehicleInfo = new VehicleInfo(i_OwnerName, i_OwnerNumber, eVehicleStatus.InProgress, vehicle);
            m_Vehicles.Add(vehicle.LicencePlate, newVehicleInfo);
        }

        public bool CheckIfExists(string i_LicencePlate)
        {
            bool exists = false;

            if (m_Vehicles.ContainsKey(i_LicencePlate))
            {
                exists = true;
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
                    licencePlate.Add(vehicleInfo.Vehicle.LicencePlate);
                }
            }
            else
            {
                eVehicleStatus vehicleStatus = (eVehicleStatus)i_VehicleStatus;
                
                foreach (VehicleInfo vehicleInfo in m_Vehicles.Values)
                {
                    if (vehicleInfo.VehicleStatus == vehicleStatus)
                    {
                        licencePlate.Add(vehicleInfo.Vehicle.LicencePlate);
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
                throw new ArgumentException("Vehicle not powered by fuel");
            }
            else
            {
                FuelTank fuelTank = (FuelTank)vehicleToFuel.PowerSource;

                if (fuelTank.FuelType == i_FuelType) {
                    fuelTank.Fuel(i_AmountOfFuel, i_FuelType);
                    vehicleToFuel.PercentageOfEnergyLeft = i_AmountOfFuel / fuelTank.MaximumPowerSourceCapacity;
                }
                else
                {
                    throw new ArgumentException("Fuel type doesn't match vehicle's fuel type");
                }
            }
        }

        public void ChargeVehicle(string i_LicencePlate, float i_HoursToCharge)
        {
            Vehicle vehicleToCharge = m_Vehicles[i_LicencePlate].Vehicle;

            if (!vehicleToCharge.isElectric())
            {
                throw new ArgumentException();
            }
            else
            {
                ((Battery)vehicleToCharge.PowerSource).Charge(i_HoursToCharge);
                vehicleToCharge.PercentageOfEnergyLeft = vehicleToCharge.PowerSource.CurrentPowerSourceCapacity / vehicleToCharge.PowerSource.MaximumPowerSourceCapacity;
            }
        }

        public string ToString(string i_LicencePlate)
        {
            return m_Vehicles[i_LicencePlate].ToString();
        }

        private List<string> generateQuestionsOfVehicle

    }
}
