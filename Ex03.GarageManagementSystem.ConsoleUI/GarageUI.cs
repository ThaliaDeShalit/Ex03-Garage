using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageUI
    {

        private GarageManager m_GarageManager;

        private readonly string r_Welcome = "Welcome to the garage, please choose by number an operation to preform:";

        private readonly string r_UserOptions =
@"1: Register a new vehicle to the garage
2: Pull all the vehicles currently in the garage, by licence plate
3: Change status of a specific vehicle in the garage
4: Inflate a vehicle's wheels to the maximum possible capacity
5: Fuel a vehicle powered by fuel
6: Charge a veicle powered by battery
7: Get all the information regarding a specific vehicle";

        private readonly string r_MainMenuInvalidInput = "Input not valid - Please enter the number corresponding to the operation you would like to preform";
        private readonly string r_GetLicencePlate = "Please enter the licence plate of the vehicle you would like to register (only digits and letters):";
        private readonly string r_LicencePlateError = "Input not valid - Please enter the licence plate using only letters and digits";

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

        private readonly string r_VehicleTypeError = "Input not valid - Please enter the number corresponding to the vehicle type you would like to register";
        private readonly string r_GetNameOfOwner = "Please enter the name of the owner of the vehicle:";
        private readonly string r_GetNameError = "Input not valid - Name can not be empty. Please enter a valid input";
        private readonly string r_GetPhoneOfOwner = "Please enter the phone of the owner of the vehicle:";
        private readonly string r_GetPhoneError = "Input not valid - Plese enter a phone number, consisting of only digits";
        private readonly string r_GetWheelManufctorName = "Please enter the name of the Wheel Manuctor";
        private readonly string r_WheelManufctorError = "Input not valid - Wheel Manufctor name can not be empty. Please enter a valid input";
        private readonly string r_GetWheelPressure = "Please enter the current amount of air pressure in the wheels";
        private readonly string r_WheelAirPressureError = "Input not valid, please enter a valid amount (float, and not more than the max capacity)";



        
        public void Run()
        {
            string userInput;
            int userInputInNumber;

            m_GarageManager = new GarageManager();

            Console.WriteLine(r_Welcome);
            
            while (true)
            {
                Console.WriteLine(r_UserOptions);
                userInput = Console.ReadLine();

                if (checkValidityOfIntInput(userInput, 1, 7, out userInputInNumber))
                {
                    Console.WriteLine(r_MainMenuInvalidInput);
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
                    Console.WriteLine(r_LicencePlateError);
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
                    vehicleProperties.Add(eVehiclePropertyType.PowerSourceCapacity, getPowerSourceCapacity());
                    vehicleProperties.Add(eVehiclePropertyType.WheelManuctorName, getWheelManuctorName());

                    switch (vehicleType)
                    {
                        case eVehicleType.FueledCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(31));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, getCarColor());
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, getAmountOfDoors());
                            break;
                        case eVehicleType.ElectricCar:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(31));
                            vehicleProperties.Add(eVehiclePropertyType.CarColor, getCarColor());
                            vehicleProperties.Add(eVehiclePropertyType.AmountOfDoors, getAmountOfDoors());
                            break;
                        case eVehicleType.FueledMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(34));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, getLicenceType());
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.ElecticMotorcycle:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(31));
                            vehicleProperties.Add(eVehiclePropertyType.LicenceType, getLicenceType());
                            vehicleProperties.Add(eVehiclePropertyType.EngineVolume, getEngineVolume());
                            break;
                        case eVehicleType.Truck:
                            vehicleProperties.Add(eVehiclePropertyType.WheelAirPressure, getCurrentWheelAirPressure(25));
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
                    Console.WriteLine(r_VehicleTypeError);
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
                    Console.WriteLine(r_GetNameError);
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
            Console.WriteLine(r_GetPhoneOfOwner);

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
                    Console.WriteLine(r_GetPhoneError);
                    continue;
                }
            }

            return input;
        }

        private string getWheelManuctorName()
        {
            string input;

            Console.WriteLine(r_GetWheelManufctorName);

            while (true)
            {
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine(r_WheelManufctorError);
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
            Console.WriteLine(r_GetWheelPressure);

            while (!inputIsValid)
            {
                input = Console.ReadLine();

                inputIsValid = float.TryParse(input, out currentAirPressure);

                if (inputIsValid)
                {
                    if (currentAirPressure > i_MaxValue || currentAirPressure < 0)
                    {
                        Console.WriteLine(r_WheelAirPressureError);
                        inputIsValid = false;
                        continue;
                    }
                }
            }

            return currentAirPressure;
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
