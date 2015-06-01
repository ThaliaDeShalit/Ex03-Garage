using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        // A dictionary of licence plate numbers and their corresponding vehicles + owner information
        private Dictionary<string, VehicleInfo> m_Vehicles = new Dictionary<string, VehicleInfo>();
        // An instance of a vehicle. At first, just a skeleton object with empty fields to be populated by the user
        // one property at a time
        private Vehicle m_CurrentVehicle;

        public void InsertNewVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleType i_VehicleType, Dictionary<eVehiclePropertyType, object> i_VehicleProporties)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_VehicleProporties);
            VehicleInfo newVehicleInfo = new VehicleInfo(i_OwnerName, i_OwnerNumber, eVehicleStatus.InProgress, vehicle);
            m_Vehicles.Add(vehicle.LicencePlate, newVehicleInfo);
        }

        // Check if a vehicle is already entered into the database
        public bool CheckIfExists(string i_LicencePlate)
        {
            bool exists = false;

            if (m_Vehicles.ContainsKey(i_LicencePlate))
            {
                exists = true;
            }

            return exists;
        }

        // Get a list as string representation of licence plates for cars currently in the garage.
        // Coule be filtered by status
        public List<string> GetLicencePlates(eVehicleStatus? i_VehicleStatus)
        {
            List<string> licencePlate = new List<string>();
            
            // No filter requested, simply display the whole list
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
                
                // Display only licence plates of vehicles mathing the requested status
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

        // Inflate all the wheels of the requested vehicle to their maximum allowed pressure
        public void InflateWheels(string i_LicencePlate)
        {
            foreach(Wheel wheel in m_Vehicles[i_LicencePlate].Vehicle.Wheels) {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        // Fuel a requested vehicle. Add the given i_AmountOfFuel to the current ammount in the FuelTank
        public void FuelVehicle(string i_LicencePlate, eFuelType i_FuelType, float i_AmountOfFuel)
        {
            Vehicle vehicleToFuel = m_Vehicles[i_LicencePlate].Vehicle;

            // If the vehicle requested is not powered by a FuelTank, throw the proper exception
            if (!vehicleToFuel.isFueled())
            {
                throw new ArgumentException("Vehicle not powered by fuel");
            }
            else
            {
                FuelTank fuelTank = (FuelTank)vehicleToFuel.PowerSource;

                // If the fuel type matched the FuelTank's FuelType, fuel the vehicle and update the PercentageOfEnergyLeft
                if (fuelTank.FuelType == i_FuelType) {
                    fuelTank.Fuel(i_AmountOfFuel, i_FuelType);
                    vehicleToFuel.PercentageOfEnergyLeft = i_AmountOfFuel / fuelTank.MaximumPowerSourceCapacity;
                }
                else
                {
                    // FuelType is not matching, throw the proper exception
                    throw new ArgumentException("Fuel type doesn't match vehicle's fuel type");
                }
            }
        }

        // Charge a requested vehicle for a given number of minutes
        public void ChargeVehicle(string i_LicencePlate, float i_MinutesToCharge)
        {
            Vehicle vehicleToCharge = m_Vehicles[i_LicencePlate].Vehicle;

            // If the vehicle requested is not powered by a Battery, throw the proper exception
            if (!vehicleToCharge.isElectric())
            {
                throw new ArgumentException("Vehicle is not powered by electricity");
            }
            else
            {
                // Send the value to charge the battery, as hours
                ((Battery)vehicleToCharge.PowerSource).Charge(i_MinutesToCharge / 60);
                vehicleToCharge.PercentageOfEnergyLeft = vehicleToCharge.PowerSource.CurrentPowerSourceCapacity / vehicleToCharge.PowerSource.MaximumPowerSourceCapacity;
            }
        }

        public string ToString(string i_LicencePlate)
        {
            return m_Vehicles[i_LicencePlate].ToString();
        }

        // Create a skeleton Vehicle instance, whose properties would be populated by the user
        public void CreateNewVehicle(string i_VehicleType)
        {
            m_CurrentVehicle = VehicleFactory.CreateVehicle(i_VehicleType);
        }

        // TODO Continue commenting from here
        public string GetQuestionOfVehicleType()
        {
            return new QuestionWithMultipleAnswers("Which type is your vehicle?", Enum.GetValues(typeof(eVehicleType))).ToString();
        }

        public List<string> GetQuestionsOfVehicleExtraProperties()
        {
            List<string> questions = new List<string>();

            for (int i = 1; i <= m_CurrentVehicle.NumOfExtraProperties; i++ )
            {
                questions.Add(m_CurrentVehicle.GetProperty(i).ToString());
            }

            return questions;
        }

        public void SetVehicleProperty(int i_PropertyIndex, string i_UserInput) 
        {
            Vehicle.SetProperty(i_PropertyIndex, i_UserInput);
        }  

        public void SetNameOwner(string i_NameOfOwner)
        {

        }

        public void SetModel(string i_Model)
        {
            m_CurrentVehicle.Model = i_Model;
        }

        public void SetLicencePlate(string i_LicencePlate)
        {
            m_CurrentVehicle.LicencePlate = i_LicencePlate;
        }

        public void SetWheelManufctorName(string i_WheelManufctorName)
        {
            foreach (Wheel wheel in m_CurrentVehicle.Wheels)
            {
                wheel.ManufctorName = i_WheelManufctorName;
            }
        }

        public void SetWheelAirPressure(string i_WheelAirPressure)
        {
            foreach (Wheel wheel in m_CurrentVehicle.Wheels)
            {
                wheel.SetCurrentAirPressure(i_WheelAirPressure);
            }
        }

        public void SetPowerSourceCapacity(string i_PowerSourceCapacity)
        {
            newPowerSource = new FuelTank(eFuelType.Octan96, k_MaxFuelCapacityCar, (float)i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);

            switch (m_CurrentVehicle.)

        }



        public void FinalizeRegistryOfVehicle(string i_NameOfOwner, string i_PhoneOfOwner)
        {
            VehicleInfo newVehicleInfo = new VehicleInfo(i_NameOfOwner, i_PhoneOfOwner, eVehicleStatus.InProgress, m_CurrentVehicle);
            m_Vehicles.Add(m_CurrentVehicle.LicencePlate, newVehicleInfo);
        }
    }
}
