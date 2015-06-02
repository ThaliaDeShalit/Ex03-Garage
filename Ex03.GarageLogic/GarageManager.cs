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
        public List<string> GetLicencePlates(string i_VehicleStatus)
        {
            eVehicleStatus? vehicleStatus = null;
            List<string> licencePlate = new List<string>();

            vehicleStatus = checkValidityOfLicencePlatesPullRequest(i_VehicleStatus);

            // No filter requested, simply display the whole list
            if (vehicleStatus == null)
            {
                foreach (VehicleInfo vehicleInfo in m_Vehicles.Values)
                {
                    licencePlate.Add(vehicleInfo.Vehicle.LicencePlate);
                }
            }
            else
            {
                
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

        private eVehicleStatus? checkValidityOfLicencePlatesPullRequest(string i_Input)
        {
            eVehicleStatus? vehicleStatus = null;
            
            if (i_Input.Length == 1)
                {
                    if (i_Input == "i" || i_Input == "I")
                    {
                        vehicleStatus = eVehicleStatus.InProgress;
                    }
                    else if (i_Input == "f" || i_Input == "F")
                    {
                        vehicleStatus = eVehicleStatus.Fixed;
                    }
                    else if (i_Input == "p" || i_Input == "P")
                    {
                        vehicleStatus = eVehicleStatus.Paid;
                    }
                    else if (!(i_Input == "a" || i_Input == "A"))
                    {
                        throwOneCharException();
                    }
                }
            else
            {
                throwOneCharException();
            }

            return vehicleStatus;
        }

        private void throwOneCharException()
        {
            throw new FormatException("Vehicle status must consist of one char");
        }

        public void ChangeVehicleStatus(string i_LicencePlate, string i_NewStatus)
        {
            eVehicleStatus vehicleStatus = VehicleInfo.GetVehicleStatus(i_NewStatus);
            
            m_Vehicles[i_LicencePlate].VehicleStatus = vehicleStatus;
        }

        // Inflate all the wheels of the requested vehicle to their maximum allowed pressure
        public void InflateWheels(string i_LicencePlate)
        {
            foreach(Wheel wheel in m_Vehicles[i_LicencePlate].Vehicle.Wheels) {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        // Fuel a requested vehicle. Add the given i_AmountOfFuel to the current ammount in the FuelTank
        public void FuelVehicle(string i_LicencePlate, string i_FuelType, string i_AmountOfFuel)
        {
            float amountOfFuel;
            FuelTank fuelTank;
            eFuelType fuelType = FuelTank.GetFuelType(i_FuelType);
            
            Vehicle vehicleToFuel = m_Vehicles[i_LicencePlate].Vehicle;

            // If the vehicle requested is not powered by a FuelTank, throw the proper exception
            if (!vehicleToFuel.isFueled())
            {
                throw new ArgumentException("Vehicle not powered by fuel");
            }
            else if (float.TryParse(i_AmountOfFuel, out amountOfFuel))
            {
                fuelTank = (FuelTank)vehicleToFuel.PowerSource;

                // If the fuel type matched the FuelTank's FuelType, fuel the vehicle and update the PercentageOfEnergyLeft
                if (fuelTank.FuelType == fuelType)
                {
                    fuelTank.Fuel(amountOfFuel, fuelType);
                    vehicleToFuel.PercentageOfEnergyLeft = amountOfFuel / fuelTank.MaximumPowerSourceCapacity;
                }
                else
                {
                    // FuelType is not matching, throw the proper exception
                    throw new ArgumentException("Fuel type doesn't match vehicle's fuel type");
                }
            }
            else
            {
                throw new FormatException("Amount of fuel must be float");
            }
        }

        // Charge a requested vehicle for a given number of minutes
        public void ChargeVehicle(string i_LicencePlate, string i_MinutesToCharge)
        {
            int minutesToCharge;
            Vehicle vehicleToCharge = m_Vehicles[i_LicencePlate].Vehicle;

            // If the vehicle requested is not powered by a Battery, throw the proper exception
            if (!vehicleToCharge.isElectric())
            {
                throw new ArgumentException("Vehicle is not powered by electricity");
            }
            else if (int.TryParse(i_MinutesToCharge, out minutesToCharge)) 
            {
                // Send the value to charge the battery, as hours
                ((Battery)vehicleToCharge.PowerSource).Charge(minutesToCharge / 60);
                vehicleToCharge.PercentageOfEnergyLeft = vehicleToCharge.PowerSource.CurrentPowerSourceCapacity / vehicleToCharge.PowerSource.MaximumPowerSourceCapacity;
            }
            else
            {
                throw new FormatException("Minutes to charge must consist of digits");
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

        // Creates a modular question for the vehicle types
        public string GetQuestionOfVehicleType()
        {
            return new QuestionWithMultipleAnswers("Which type is your vehicle?", Enum.GetValues(typeof(eVehicleType))).ToString();
        }

        // creates a list of all the questions regarding the vehicle extra properties
        public List<string> GetQuestionsOfVehicleExtraProperties()
        {
            List<string> questions = new List<string>();

            for (int i = 1; i <= m_CurrentVehicle.NumOfExtraProperties; i++ )
            {
                questions.Add(m_CurrentVehicle.GetProperty(i).ToString());
            }

            return questions;
        }

        // send the string inputs to the relevant vehicle to set it;s property
        public void SetVehicleProperty(int i_PropertyIndex, string i_UserInput) 
        {
            m_CurrentVehicle.SetProperty(i_PropertyIndex, i_UserInput);
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
            m_CurrentVehicle.PowerSource.SetCurrentPowerSourceCapacity(i_PowerSourceCapacity);
            m_CurrentVehicle.PercentageOfEnergyLeft = m_CurrentVehicle.PowerSource.CurrentPowerSourceCapacity / m_CurrentVehicle.PowerSource.MaximumPowerSourceCapacity;
        }

        // once the vehicle has been created succefully, the vehicle is put in the DB
        public void FinalizeRegistryOfVehicle(string i_NameOfOwner, string i_PhoneOfOwner)
        {
            VehicleInfo newVehicleInfo = new VehicleInfo(i_NameOfOwner, i_PhoneOfOwner, eVehicleStatus.InProgress, m_CurrentVehicle);
            m_Vehicles.Add(m_CurrentVehicle.LicencePlate, newVehicleInfo);
        }

        // updates the status of the vehicle if it already exists
        public void VehicleAlreadyExistsUpdateStatus(string i_LicenePlate)
        {
            m_Vehicles[i_LicenePlate].VehicleStatus = eVehicleStatus.InProgress;
        }
    }
}
