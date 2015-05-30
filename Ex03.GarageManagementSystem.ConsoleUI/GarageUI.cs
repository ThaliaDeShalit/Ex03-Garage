using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageUI
    {

        private GarageManager m_GarageManager;

        private const float k_MaxFuelCapacityMotorcycle = 8f;
        private const float k_MaxBatteryCapacityMotorcycle = 1.2f;
        private const float k_MaxFuelCapacityCar = 35f;
        private const float k_MaxBatteryCapacityCar = 2.2f;
        private const float k_MaxFuelCapacityTruck = 170f;
        private const float k_MaxAirPressureCarAndElectricMotorcycle = 31f;
        private const float k_MaxAirPressureFuelMotorcycle = 34f;
        private const float k_MaxAirPressureTruck = 25f;

        private readonly string r_WelcomeMessage = "Welcome to the garage, please choose by number an operation to preform:";

        private readonly string r_UserOptions =
@"1: Register a new vehicle to the garage
2: Show all the vehicles currently in the garage, by licence plate
3: Change status of a specific vehicle in the garage
4: Inflate a vehicle's wheels to the maximum possible capacity
5: Fuel a vehicle powered by fuel
6: Charge a veicle powered by battery
7: Show all the information for a selected vehicle";

        private readonly string r_InvalidUserOption = "Input not valid. Please enter the number corresponding with the operation you would like to perform.";
        private readonly string r_GetLicencePlate = "Please enter the licence plate of the vehicle you would like to register (digits and letters only):";
        private readonly string r_InvalidLicencePlate = "Input not valid. Please enter the licence plate using only letters and digits.";

        private readonly string r_CarAlreadyExists =
@"Vehicle with licence plate %s already exists in the garage.
It's status has been changed to 'In Progress'.";

        private readonly string r_GetVehicleType =
@"Please enter the vehicle type you would like to register:
1: Fueled Car
2: Electric Car
3: Fueled Motorcycle
4: Electric Motorcycle
5: Truck";

        private readonly string r_InvalidVehicleType = "The selected vehicle type is not supported. Please select one of the supported vehicle types displayed above.";
        private readonly string r_GetNameOfOwner = "Please enter the name of the owner of the vehicle:";
        private readonly string r_InvalidOwnerName = "Input cannot be empty. Please enter the name of the vehicle owner:";
        private readonly string r_GetOwnerPhoneNumber = "Enter the owner's phone number:";
        private readonly string r_InvalidOwnerPhoneNumber = "Invalid input. Please enter a phone number, consisting of digits only.";
        private readonly string r_GetWheelManufacturerName = "Enter the wheels' manufacturer name:";
        private readonly string r_InvalidWheelManufacturerName = "Input cannot be empty. Please enter the name of the wheels' manufacturer:";
        private readonly string r_GetWheelAirPressure = "Enter the current air pressure in the wheels:";
        private readonly string r_InvalidWheelAirPressure = "Input not valid. Please enter a positive float between 0 and the maximum air pressure of the wheels.";

        // Car color
        private readonly string r_GetCarColor =
@"What color is your car? Select one of the supported colors:
1: Green
2: Red
3: White
4: Black";

        private readonly string r_InvalidCarColor = "Selected number is not supported. Please select a number between 0 and 4.";

        // Amount of doors
        private readonly string r_GetAmountOfDoors = "How many doors does your vehicle have? (one of 2, 3, 4 or 5)";
        private readonly string r_InvalidAmountOfDoors = "The number of doors you entered is not supported by this garage. We only repair vehicles with 2 to 5 doors.";

        // Current fuel capacity
        private readonly string r_GetCurrentFuelCapacity = "Enter current fuel capacity:";
        private readonly string r_InvalidFuelCapacity = "The amount of fuel you entered is not possible. Please make sure the value you entered is a positive integer between 0 and the maximum capacity of your fuel tank.";

        // Current battery capacity
        private readonly string r_GetBatteryCapacity = "Enter current battery capacity:";
        private readonly string r_InvalidBatteryCapacity = "The capacity entered is not possible. Please make sure the value you entered is a positive integer between 0 and the maximum capacity of your battery.";

        // Current powersource capacity
        private readonly string r_GetPowerSourceCapacity = "Enter current power capacity (fuel amount/ battery charge):";
        private readonly string r_InvalidPowerSourceCapacity = "The value entered is not possible. Please enter a positive value between 0 and the %d.";

        // Licence type
        private readonly string r_GetLicenceType =
@"Which licence type is your motorcycle? Select one of the possible types:
1: A
2: A2
3: AB
4: B1";
        private readonly string r_InvalidLicenceType = "The selected licence type is not supported. Please select one of the supported licence types.";

        // Engine volume
        private readonly string r_GetEngineVolume = "Enter the volume of your engine:";
        private readonly string r_InvalidEngineVolume = "Invalid value. Please enter a positive integer value.";

        // Model name
        private readonly string r_GetCarModelName = "Enter your vehicle's model name:";
        private readonly string r_InvalidCarModelName = "Please enter the name of your vehicle's model.";

        // Carrying hazardous materials
        private readonly string r_GetCarryingHazardousMaterials = "Is your vehicle carrying hazardous materials? (y/n)";
        private readonly string r_InvalidCarryingHazardousMaterials = "Invalid input. Please select either 'y' or 'n'.";

        // Current carry weight
        private readonly string r_GetCurrentCarryingWeight = "Enter the current weight your vehicle is carrying:";
        private readonly string r_InvalidCurrentCarryingWeight = "Invalid input. Please enter a positive integer.";


        public void Run()
        {
            string userInput;
            int userInputInNumber;

            m_GarageManager = new GarageManager();

            Console.WriteLine(r_WelcomeMessage);

            while (true)
            {
                Console.WriteLine(r_UserOptions);
                userInput = Console.ReadLine();

                if (checkValidityOfIntInput(userInput, 1, 7, out userInputInNumber))
                {
                    Console.WriteLine(r_InvalidUserOption);
                    continue;
                }

                switch ((eGarageOperations)userInputInNumber)
                {
                    case eGarageOperations.RegisterNewCar:
                        registerNewCar();
                        break;
                    case eGarageOperations.PullAllVehicles:
                        pullAllVehicles();
                        break;
                    case eGarageOperations.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case eGarageOperations.InflateWheels:
                        inflateWheels();
                        break;
                    case eGarageOperations.FuelVehicle:
                        fuelVehicle();
                        break;
                    case eGarageOperations.ChargeVehicle:
                        chargeVehicle();
                        break;
                    case eGarageOperations.AllInfoOfVehicle:
                        getAllInfoOfVehicle();
                        break;
                }
            }

        }

        private void registerNewCar()
        {
            Console.WriteLine(r_GetLicencePlate);
            bool inputIsValid = false;
            bool carAlreadyExists = false;
            string licencePlate;

            eVehicleType vehicleType;
            string nameOfOwner;
            string phoneNumberOfOwner;
            Dictionary<eVehiclePropertyType, object> vehicleProperties = new Dictionary<eVehiclePropertyType, object>();
            float maxCapacityOfAirPressure = 0;

            while (!inputIsValid)
            {
                licencePlate = Console.ReadLine();

                inputIsValid = true;
                foreach (char character in licencePlate)
                {
                    if (!char.IsLetterOrDigit(character))
                    {
                        inputIsValid = false;
                        break;
                    }
                }

                if (!inputIsValid)
                {
                    Console.WriteLine(r_InvalidLicencePlate);
                    continue;
                }

                // if we got here it means the licence plate is valid
                carAlreadyExists = m_GarageManager.CheckIfExists(licencePlate);

                if (carAlreadyExists)
                {
                    Console.WriteLine(r_CarAlreadyExists, licencePlate);
                    break;
                }
                else
                {
                    vehicleType = (eVehicleType)getVehicleType();
                    nameOfOwner = getNameOfOwner();
                    phoneNumberOfOwner = getPhoneNumberOfOwner();

                    vehicleProperties.Add(eVehiclePropertyType.Model, getVehicleModel());
                    vehicleProperties.Add(eVehiclePropertyType.LicencePlate, licencePlate);
                    vehicleProperties.Add(eVehiclePropertyType.WheelManuctorName, getWheelManuctorName());

                    switch (vehicleType)
                    {
                        case eVehicleType.FueledCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(k_MaxAirPressureCarAndElectricMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity(k_MaxFuelCapacityCar));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, getCarColor());
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, getAmountOfDoors());
                            break;
                        case eVehicleType.ElectricCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(k_MaxAirPressureCarAndElectricMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity(k_MaxBatteryCapacityCar));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, getCarColor());
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, getAmountOfDoors());
                            break;
                        case eVehicleType.FueledMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(k_MaxAirPressureFuelMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity(k_MaxFuelCapacityMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, getLicenceType());
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.ElecticMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(k_MaxAirPressureCarAndElectricMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity(k_MaxBatteryCapacityMotorcycle));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, getLicenceType());
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.Truck:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(k_MaxAirPressureTruck));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity(k_MaxFuelCapacityTruck));
                            vehicleProperties.Add(eVehiclePropertyType.CarryingHazardousMaterials, getCarryingHazardousMaterials());
                            vehicleProperties.Add(eVehiclePropertyType.CarryWeight, getCurrentCarryWeight());
                            break;
                    }


                    m_GarageManager.InsertNewVehicle(nameOfOwner, phoneNumberOfOwner, vehicleType, vehicleProperties);
                }
            }
        }

        private int getVehicleType()
        {
            string input;
            int inputInInt = 0;

            Console.WriteLine(r_GetVehicleType);
            while (true)
            {
                input = Console.ReadLine();

                if (!checkValidityOfIntInput(input, 1, 5, out inputInInt))
                {
                    Console.WriteLine(r_InvalidVehicleType);
                    continue;
                }
                else
                {
                    break;
                }
            }

            return inputInInt;
        }

        private string getNameOfOwner()
        {
            string input;

            Console.WriteLine(r_GetNameOfOwner);

            while (true)
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine(r_InvalidOwnerName);
                    continue;
                }
                else
                {
                    break;
                }
            }

            return input;
        }

        private string getPhoneNumberOfOwner()
        {
            string input = string.Empty;
            bool inputIsValid = false;
            Console.WriteLine(r_GetOwnerPhoneNumber);

            while (!inputIsValid)
            {
                input = Console.ReadLine();

                inputIsValid = true;
                foreach (char characther in input)
                {
                    if (!char.IsDigit(characther))
                    {
                        inputIsValid = false;
                        break;
                    }
                }

                if (!inputIsValid)
                {
                    Console.WriteLine(r_InvalidOwnerPhoneNumber);
                    continue;
                }
            }

            return input;
        }

        private string getWheelManufacturerName()
        {
            string input;

            Console.WriteLine(r_GetWheelManufacturerName);

            while (true)
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine(r_InvalidWheelManufacturerName);
                    continue;
                }
                else
                {
                    break;
                }
            }

            return input;
        }

        private float getCurrentWheelAirPressure(float i_MaxValue)
        {
            string input;
            bool inputIsValid = false;
            float currentAirPressure = 0;
            Console.WriteLine(r_GetWheelAirPressure);

            while (!inputIsValid)
            {
                input = Console.ReadLine();

                inputIsValid = float.TryParse(input, out currentAirPressure);

                if (inputIsValid)
                {
                    if (currentAirPressure > i_MaxValue || currentAirPressure < 0)
                    {
                        Console.WriteLine(r_InvalidWheelAirPressure);
                        inputIsValid = false;
                        continue;
                    }
                }
            }

            return currentAirPressure;
        }

        private string getVehicleModel() {}

        private bool checkValidityOfIntInput(string i_Input, int i_Min, int i_Max, out int io_InputInInt)
        {
            bool isValid = false;

            isValid = int.TryParse(i_Input, out io_InputInInt);
            if (isValid)
            {
                if (io_InputInInt < i_Min || io_InputInInt > i_Max)
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }

    enum eGarageOperations
    {
        RegisterNewCar,
        PullAllVehicles,
        ChangeVehicleStatus,
        InflateWheels,
        FuelVehicle,
        ChargeVehicle,
        AllInfoOfVehicle
    }
}
