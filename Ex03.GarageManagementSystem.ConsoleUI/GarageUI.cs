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

        private const string k_WelcomeMessage = "Welcome to the garage, please choose by number an operation to preform:";

        // User options
        private const string k_UserOptions =
@"1: Register a new vehicle to the garage
2: Show all the vehicles currently in the garage, by licence plate
3: Change status of a specific vehicle in the garage
4: Inflate a vehicle's wheels to the maximum possible capacity
5: Fuel a vehicle powered by fuel
6: Charge a veicle powered by battery
7: Show all the information for a selected vehicle

8: To exit";
        private const string k_InvalidUserOption = "Input not valid. Please enter the number corresponding with the operation you would like to perform.";
        
        // exit
        private const string k_ExitPrompt = "Goodbye! (please press enter to exit)";

        // Licence plate
        private const string k_GetLicencePlate = "Please enter the licence plate of the vehicle you would like to register (digits and letters only):";
        private const string k_InvalidLicencePlate = "Input not valid. Please enter the licence plate using only letters and digits.";

        private const string k_VehicleAlreadyExists =
@"Vehicle with licence plate %s already exists in the garage.
It's status has been changed to 'In Progress'.";

        // Vehicle type
        private const string k_GetVehicleType =
@"Please enter the vehicle type you would like to register:
1: Fueled Car
2: Electric Car
3: Fueled Motorcycle
4: Electric Motorcycle
5: Truck";
        private const string k_InvalidVehicleType = "The selected vehicle type is not supported. Please select one of the supported vehicle types displayed above.";
        
        // Owner Name
        private const string k_GetNameOfOwner = "Please enter the name of the owner of the vehicle:";
        private const string k_InvalidOwnerName = "Input cannot be empty. Please enter the name of the vehicle owner:";
        
        // Owner phone number
        private const string k_GetOwnerPhoneNumber = "Enter the owner's phone number:";
        private const string k_InvalidOwnerPhoneNumber = "Invalid input. Please enter a phone number, consisting of digits only.";
        
        // Wheel manufctor name
        private const string k_GetWheelManufacturerName = "Enter the wheels' manufacturer name:";
        private const string k_InvalidWheelManufacturerName = "Input cannot be empty. Please enter the name of the wheels' manufacturer:";

        // Wheel air pressure
        private const string k_GetWheelAirPressure = "Enter the current air pressure in the wheels:";
        private const string k_InvalidWheelAirPressure = "Input not valid. Please enter a positive float between 0 and the maximum air pressure of the wheels.";

        // Car color
        private const string k_GetCarColor =
@"What color is your car? Select one of the supported colors:
1: Green
2: Red
3: White
4: Black";

        private const string k_InvalidCarColor = "Selected number is not supported. Please select a number between 0 and 4.";

        // Amount of doors
        private const string k_GetAmountOfDoors = "How many doors does your vehicle have? (one of 2, 3, 4 or 5)";
        private const string k_InvalidAmountOfDoors = "The number of doors you entered is not supported by this garage. We only repair vehicles with 2 to 5 doors.";

        // Current fuel capacity
        private const string k_GetCurrentFuelCapacity = "Enter current fuel capacity:";
        private const string k_InvalidFuelCapacity = "The amount of fuel you entered is not possible. Please make sure the value you entered is a positive integer between 0 and the maximum capacity of your fuel tank.";

        // Current battery capacity
        private const string k_GetBatteryCapacity = "Enter current battery capacity:";
        private const string k_InvalidBatteryCapacity = "The capacity entered is not possible. Please make sure the value you entered is a positive integer between 0 and the maximum capacity of your battery.";

        // Current powersource capacity
        private const string k_GetPowerSourceCapacity = "Enter current power capacity (fuel amount/ battery charge):";
        private const string k_InvalidPowerSourceCapacity = "The value entered is not possible. Please enter a positive value between 0 and the %d.";

        // Licence type
        private const string k_GetLicenceType =
@"Which licence type is your motorcycle? Select one of the possible types:
1: A
2: A2
3: AB
4: B1";
        private const string k_InvalidLicenceType = "The selected licence type is not supported. Please select one of the supported licence types.";

        // Engine volume
        private const string k_GetEngineVolume = "Enter the volume of your engine:";
        private const string k_InvalidEngineVolume = "Invalid value. Please enter a positive integer value.";

        // Model name
        private const string k_GetVehicleModelName = "Enter your vehicle's model name:";
        private const string k_InvalidVehicleModelName = "Please enter the name of your vehicle's model.";

        // Carrying hazardous materials
        private const string k_GetCarryingHazardousMaterials = "Is your vehicle carrying hazardous materials? (y/n)";
        private const string k_InvalidCarryingHazardousMaterials = "Invalid input. Please select either 'y' or 'n'.";

        // Current carry weight
        private const string k_GetCurrentCarryingWeight = "Enter the current weight your vehicle is carrying:";
        private const string k_InvalidCurrentCarryingWeight = "Invalid input. Please enter a positive integer.";

        private const string k_EnterToContinue = "Please press enter to continue";

        // Vehicle type to pull
        private const string k_GetVehicleTypeToPull = "Please enter whether you would like to pull all vehicles, or vehcile in a specific status - In progress, fixed or paid: [a/i/f/p]";
        private const string k_InvalidVehicleTypeToPull = "Invalid input. Please enter either a for all vehicles, i for vehicles in progress, f for fixed or p for paid";

        public void Run()
        {
            string userInput;
            int userInputInNumber;
            bool quit = false;

            m_GarageManager = new GarageManager();

            Console.WriteLine(k_WelcomeMessage);

            while (true)
            {
                Console.WriteLine(k_UserOptions);
                userInput = Console.ReadLine();

                if (checkValidityOfIntInput(userInput, 1, 7, out userInputInNumber))
                {
                    Console.WriteLine(k_InvalidUserOption);
                    continue;
                }

                switch ((eGarageOperations)userInputInNumber)
                {
                    case eGarageOperations.RegisterNewCar:
                        Console.Clear();
                        registerNewCar();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.PullAllVehicles:
                        Console.Clear();
                        pullAllVehicles();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.ChangeVehicleStatus:
                        Console.Clear();
                        changeVehicleStatus();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.InflateWheels:
                        Console.Clear();
                        inflateWheels();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.FuelVehicle:
                        Console.Clear();
                        fuelVehicle();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.ChargeVehicle:
                        Console.Clear();
                        chargeVehicle();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.AllInfoOfVehicle:
                        Console.Clear();
                        getAllInfoOfVehicle();
                        pressEnterToContinue();
                        break;
                    case eGarageOperations.Exit:
                        Console.Clear();
                        quit = true;
                        break;
                }

                if (quit)
                {
                    break;
                }
            }

            Console.WriteLine(k_ExitPrompt);
            Console.ReadLine();
        }

        private void registerNewCar()
        {
            Console.WriteLine(k_GetLicencePlate);
            bool inputIsValid = false;
            bool carAlreadyExists = false;
            string licencePlate;

            eVehicleType vehicleType;
            string nameOfOwner;
            string phoneNumberOfOwner;
            Dictionary<eVehiclePropertyType, object> vehicleProperties = new Dictionary<eVehiclePropertyType, object>();

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
                    Console.WriteLine(k_InvalidLicencePlate);
                    continue;
                }

                // if we got here it means the licence plate is valid
                carAlreadyExists = m_GarageManager.CheckIfExists(licencePlate);

                if (carAlreadyExists)
                {
                    Console.WriteLine(k_VehicleAlreadyExists, licencePlate);
                    break;
                }
                else
                {
                    vehicleType = (eVehicleType)getIntRepresentationOfEnum(1, 5, k_GetVehicleType, k_InvalidVehicleType);
                    nameOfOwner = getNameOfOwner();
                    phoneNumberOfOwner = getPhoneNumberOfOwner();

                    vehicleProperties.Add(eVehiclePropertyType.Model, getTextInput(k_GetVehicleModelName, k_InvalidVehicleModelName));
                    vehicleProperties.Add(eVehiclePropertyType.LicencePlate, licencePlate);
                    vehicleProperties.Add(eVehiclePropertyType.WheelManuctorName, getTextInput(k_GetWheelManufacturerName, k_InvalidWheelManufacturerName));

                    switch (vehicleType)
                    {
                        case eVehicleType.FueledCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getFloatInput(k_MaxAirPressureCarAndElectricMotorcycle, k_GetWheelAirPressure, k_InvalidWheelAirPressure));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getFloatInput(k_MaxFuelCapacityCar, k_GetPowerSourceCapacity, k_InvalidPowerSourceCapacity));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, (eCarColor)getIntRepresentationOfEnum(1, 4, k_GetCarColor, k_InvalidCarColor));
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, (eAmountOfDoors)getIntRepresentationOfEnum(2, 5, k_GetAmountOfDoors, k_InvalidAmountOfDoors));
                            break;
                        case eVehicleType.ElectricCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getFloatInput(k_MaxAirPressureCarAndElectricMotorcycle, k_GetWheelAirPressure, k_InvalidWheelAirPressure));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getFloatInput(k_MaxBatteryCapacityCar, k_GetPowerSourceCapacity, k_InvalidPowerSourceCapacity));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, (eCarColor)getIntRepresentationOfEnum(1, 4, k_GetCarColor, k_InvalidCarColor));
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, (eAmountOfDoors)getIntRepresentationOfEnum(2, 5, k_GetAmountOfDoors, k_InvalidAmountOfDoors));
                            break;
                        case eVehicleType.FueledMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getFloatInput(k_MaxAirPressureFuelMotorcycle, k_GetWheelAirPressure, k_InvalidWheelAirPressure));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getFloatInput(k_MaxFuelCapacityMotorcycle, k_GetPowerSourceCapacity, k_InvalidPowerSourceCapacity));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, (eLicenceType) getIntRepresentationOfEnum(1, 4, k_GetLicenceType, k_InvalidLicenceType));
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.ElecticMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getFloatInput(k_MaxAirPressureCarAndElectricMotorcycle, k_GetWheelAirPressure, k_InvalidWheelAirPressure));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getFloatInput(k_MaxBatteryCapacityMotorcycle, k_GetPowerSourceCapacity, k_InvalidPowerSourceCapacity));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, (eLicenceType) getIntRepresentationOfEnum(1, 4, k_GetLicenceType, k_InvalidLicenceType));
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.Truck:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getFloatInput(k_MaxAirPressureTruck, k_GetWheelAirPressure, k_InvalidWheelAirPressure));
                            vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getFloatInput(k_MaxFuelCapacityTruck, k_GetPowerSourceCapacity, k_InvalidPowerSourceCapacity));
                            vehicleProperties.Add(eVehiclePropertyType.CarryingHazardousMaterials, getCarryingHazardousMaterials());
                            vehicleProperties.Add(eVehiclePropertyType.CarryWeight, getFloatInput(float.MaxValue, k_GetCurrentCarryingWeight, k_InvalidCurrentCarryingWeight));
                            break;
                    }

                    m_GarageManager.InsertNewVehicle(nameOfOwner, phoneNumberOfOwner, vehicleType, vehicleProperties);
                }
            }
        }

        private int getIntRepresentationOfEnum(int i_MinValue, int i_MaxValue, string i_RequestPrompt, string i_ErrorPrompt)
        {
            string input;
            int inputInInt = 0;

            Console.WriteLine(i_RequestPrompt);
            while (true)
            {
                input = Console.ReadLine();

                if (checkValidityOfIntInput(input, i_MinValue, i_MaxValue, out inputInInt))
                {
                    break;                    
                }

                Console.WriteLine(i_ErrorPrompt);
            }

            return inputInInt;
        }

        private string getNameOfOwner()
        {
            string input;

            Console.WriteLine(k_GetNameOfOwner);

            while (true)
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine(k_InvalidOwnerName);
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
            Console.WriteLine(k_GetOwnerPhoneNumber);

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
                    Console.WriteLine(k_InvalidOwnerPhoneNumber);
                    continue;
                }
            }

            return input;
        }

        private string getWheelManufacturerName()
        {
            string input;

            Console.WriteLine(k_GetWheelManufacturerName);

            while (true)
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine(k_InvalidWheelManufacturerName);
                    continue;
                }
                else
                {
                    break;
                }
            }

            return input;
        }

        private float getFloatInput(float i_MaxValue, string i_RequestPrompt, string i_ErrorPrompt)
        {
            string input;
            bool inputIsValid = false;
            float inputInFloat = 0;
            Console.WriteLine(i_RequestPrompt);

            while (!inputIsValid)
            {
                input = Console.ReadLine();

                inputIsValid = float.TryParse(input, out inputInFloat);

                if (inputIsValid)
                {
                    if (inputInFloat > i_MaxValue || inputInFloat < 0)
                    {
                        Console.WriteLine(i_ErrorPrompt);
                        inputIsValid = false;
                        continue;
                    }
                }
            }

            return inputInFloat;
        }

        private string getTextInput(string i_RequestPrompt, string i_ErrorPrompt)
        {
            string input;

            Console.WriteLine(i_RequestPrompt);

            while (true)
            {
                input = Console.ReadLine();

                if (input != string.Empty)
                {
                    break;
                }

                Console.WriteLine(i_ErrorPrompt);
            }

            return input;
        }

        private int getEngineVolume()
        {
            string input;
            int inputInInt = 0;

            Console.WriteLine(k_GetEngineVolume);
            while (true)
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out inputInInt))
                {
                    break;
                }

                Console.WriteLine(k_InvalidEngineVolume);
            }

            return inputInInt;
        }

        private bool getCarryingHazardousMaterials()
        {
            string input;
            bool isHazardous;

            Console.WriteLine(k_GetCarryingHazardousMaterials);
            while (true)
            {
                input = Console.ReadLine();
                
                if (input.Length == 1)
                {
                    if (input == "y" || input == "Y")
                    {
                        isHazardous = true;
                        break;
                    } else if (input == "n" || input == "N") {
                        isHazardous = false;
                        break;
                    }
                }

                Console.WriteLine(k_InvalidCarryingHazardousMaterials);
            }

            return isHazardous;
        }

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

        private void pressEnterToContinue()
        {
            Console.WriteLine();
            Console.WriteLine(k_EnterToContinue);
            Console.ReadLine();
            Console.Clear();
        }

        // Todo - talk to nadav regarding the implementation
        private void pullAllVehicles()
        {
            string input;
            eVehicleStatus? vehicleStatus = null;
            bool isValid = false;
            List<string> vehicles;

            Console.WriteLine(k_GetVehicleTypeToPull);

            while (true)
            {
                input = Console.ReadLine();

                if (input.Length == 1)
                {
                    if (input == "a" || input == "A")
                    {
                        isValid = true;
                    }
                    else if (input == "i" || input == "I")
                    {
                        vehicleStatus = eVehicleStatus.InProgress;
                        isValid = true;
                    }
                    else if (input == "f" || input == "F")
                    {
                        vehicleStatus = eVehicleStatus.Fixed;
                        isValid = true;
                    }
                    else if (input == "p" || input == "P")
                    {
                        vehicleStatus = eVehicleStatus.Paid;
                        isValid = true;
                    }
                }

                if (isValid)
                {
                    vehicles = m_GarageManager.GetLicencePlates(vehicleStatus);

                    foreach (string licencePlate in vehicles)
                    {
                        Console.WriteLine(licencePlate);
                    }
                    
                    break;
                }

                Console.WriteLine(k_InvalidVehicleTypeToPull);
            }
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
        AllInfoOfVehicle,
        Exit
    }
}
