using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class UI
    {
        private GarageManager m_GarageManager;

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

8: To exit
--Press Exit in any of the pages to exit to the main menu--";
        private const string k_InvalidUserOption = "Input not valid. Please enter the number corresponding with the operation you would like to perform.";

        // exit
        private const string k_ExitPrompt = "Goodbye! (please press enter to exit)";

        // Licence plate
        private const string k_GetLicencePlateToRegister =
@"Please enter the licence plate of the vehicle you would like to register (digits and letters only):
--Please note that this is the last place in this operation to use the 'exit' option--";
        private const string k_InvalidLicencePlate = "Input not valid. Please enter the licence plate using only letters and digits.";

        private const string k_VehicleAlreadyExists =
@"Vehicle with this licence plate already exists in the garage.
It's status has been changed to 'In Progress'.";

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

        // Current powersource capacity
        private const string k_GetPowerSourceCapacity = "Enter current power capacity (fuel amount/ battery charge):";
        private const string k_InvalidPowerSourceCapacity = "The value entered is not possible. Please enter a positive value between 0 and the %d.";

        // Model name
        private const string k_GetVehicleModelName = "Enter your vehicle's model name:";
        private const string k_InvalidVehicleModelName = "Please enter the name of your vehicle's model.";

        private const string k_VehicleRegisteredSuccefully = "Vehicle registered succefully";
        private const string k_VehicleChangedStatusSuccefully = "Changed Vehicle status succefully";
        private const string k_VehicleInflatedSuccefully = "Inflated wheels succefully";
        private const string k_VehicleFuledSuccefully = "Vehicle fueled succefully";
        private const string k_VehicleChargedSuccefully = "Vehicle charged succefully";

        private const string k_EnterToContinue = "Please press enter to continue";

        private const string k_GetLicencePlate = "Please enter the licence plate";

        // Vehicle type to pull
        private const string k_GetVehicleTypeToPull = "Please enter whether you would like to pull all vehicles, or vehcile in a specific status - In progress, fixed or paid: [a/i/f/p]";
        private const string k_InvalidVehicleTypeToPull = "Invalid input. Please enter either a for all vehicles, i for vehicles in progress, f for fixed or p for paid";

        private const string k_GetVehicleStatus =
@"To which status would you like to change your vehicle status to?
1: In progress
2: Fixed
3: Paid";
        private const string k_InvalidVehicleStatus = "Invalid input, please enter a digit that corresponds to one of the supported statuses";

        private const string k_GetFuelType =
@"Which fuel type would you like to use to fuel your vehicle?
1: Soler
2: Octan 95
3: Octan 96
4: Octan 98";
        private const string k_InvalidFuelType = "Invalid input, please enter a digit that corresponds to one the supported fuel type";

        private const string k_GetAmountOfFuel = "Please enter the amount of fuel you would like to fuel your vehicle with";
        private const string k_InvalidAmountOfFuel = "Invalid input, please enter a float to represent the amount of fuel you would like to fuel";

        private const string k_GetAmountOfMinToCharge = "Please enter the amount of minutes to charge your vehicle with";
        private const string k_InvalidAmountOfMinToCharge = "Invalid input, please enter an int to represent the amount of minutes to charge your vehicle";

        private const string k_LicencePlateNotInDatabase = "Vehicle does not exist in database, please re-enter licence plate";

        public void Run()
        {
            string userInput;
            int userInputInNumber;
            bool quit = false;
            bool invalidInput = false;

            m_GarageManager = new GarageManager();

            Console.WriteLine(k_WelcomeMessage);

            while (true)
            {
                if (!invalidInput)
                {
                    Console.WriteLine(k_UserOptions);
                }

                userInput = Console.ReadLine();

                if (checkIfExit(userInput))
                {
                    return;
                }

                if (!checkValidityOfIntInput(userInput, 1, 8, out userInputInNumber))
                {
                    Console.WriteLine(k_InvalidUserOption);
                    invalidInput = true;
                    continue;
                }
                else
                {
                    invalidInput = false;
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
                    case eGarageOperations.CompleteVehicleInfo:
                        Console.Clear();
                        getCompleteVehicleInfo();
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
            string licencePlate;
            bool inputIsValid = false;
            bool carAlreadyExists;
            string nameOfOwner;
            string phoneNumberOfOwner;
            List<string> extraPropertiesQuestions;
            string input;
            bool isValid = true;

            Console.WriteLine(k_GetLicencePlateToRegister);
            while (true)
            {
                licencePlate = Console.ReadLine();

                if (checkIfExit(licencePlate))
                {
                    return;
                }

                inputIsValid = true;
                foreach (char character in licencePlate)
                {
                    if (!char.IsLetterOrDigit(character))
                    {
                        inputIsValid = false;
                        break;
                    }
                }

                if (inputIsValid)
                {
                    break;
                }

                Console.WriteLine(k_InvalidLicencePlate);
            }

            // if we got here it means the licence plate is valid
            carAlreadyExists = m_GarageManager.CheckIfExists(licencePlate);

            if (carAlreadyExists)
            {
                m_GarageManager.VehicleAlreadyExistsUpdateStatus(licencePlate);
                Console.WriteLine(k_VehicleAlreadyExists);
            }
            else
            {
                getVehicleTypeAndCreateVehicle();
                nameOfOwner = getNameOfOwner();
                phoneNumberOfOwner = getPhoneNumberOfOwner();

                getAndSetVehicleModel();
                setLicencePlate(licencePlate);
                getAndSetWheelManucftorName();
                getAndSetWheelAirPressure();
                getAndSetPowerSourceCapacity();

                extraPropertiesQuestions = m_GarageManager.GetQuestionsOfVehicleExtraProperties();

                for (int i = 1; i <= extraPropertiesQuestions.Count; i++)
                {
                    if (isValid)
                    {
                        Console.WriteLine(extraPropertiesQuestions[i - 1]);
                    }
                    input = Console.ReadLine();

                    try
                    {
                        m_GarageManager.SetVehicleProperty(i, input);
                        isValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        i--;
                        isValid = false;
                    }
                }

                m_GarageManager.FinalizeRegistryOfVehicle(nameOfOwner, phoneNumberOfOwner);

                Console.WriteLine(k_VehicleRegisteredSuccefully);
            }
        }

        private void getVehicleTypeAndCreateVehicle()
        {
            string input;
            Console.WriteLine(m_GarageManager.GetQuestionOfVehicleType());

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    m_GarageManager.CreateNewVehicle(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string getLicencePlate(out bool o_Exit)
        {
            string licencePlate;
            bool inputIsValid = false;

            Console.WriteLine(k_GetLicencePlate);
            while (true)
            {
                licencePlate = Console.ReadLine();

                if (checkIfExit(licencePlate))
                {
                    o_Exit = true;
                    break;
                }
                else
                {
                    o_Exit = false;

                    inputIsValid = true;
                    foreach (char character in licencePlate)
                    {
                        if (!char.IsLetterOrDigit(character))
                        {
                            inputIsValid = false;
                            break;
                        }
                    }
                    if (inputIsValid)
                    {
                        if (!m_GarageManager.CheckIfExists(licencePlate))
                        {
                            Console.WriteLine(k_LicencePlateNotInDatabase);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(k_InvalidLicencePlate);
                    }
                }
            }

            return licencePlate;
        }

        private void getAndSetVehicleModel()
        {
            string input;
            Console.WriteLine(k_GetVehicleModelName);

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    m_GarageManager.SetModel(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void setLicencePlate(string i_LicencePlate)
        {
            while (true)
            {
                try
                {
                    m_GarageManager.SetLicencePlate(i_LicencePlate);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter a valid licence plate");
                    i_LicencePlate = Console.ReadLine();

                    if (checkIfExit(i_LicencePlate))
                    {
                        return;
                    }
                }
            }

        }

        private void getAndSetWheelManucftorName()
        {
            string input;
            Console.WriteLine(k_GetWheelManufacturerName);

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    m_GarageManager.SetWheelManufctorName(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getAndSetWheelAirPressure()
        {
            string input;
            Console.WriteLine(k_GetWheelAirPressure);

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    m_GarageManager.SetWheelAirPressure(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getAndSetPowerSourceCapacity()
        {
            string input;
            Console.WriteLine(k_GetPowerSourceCapacity);

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    m_GarageManager.SetPowerSourceCapacity(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        private void pullAllVehicles()
        {
            string input;
            List<string> vehicles;

            Console.WriteLine(k_GetVehicleTypeToPull);

            while (true)
            {
                input = Console.ReadLine();

                if (checkIfExit(input))
                {
                    return;
                }

                try
                {
                    vehicles = m_GarageManager.GetLicencePlates(input);
                    foreach (string licencePlate in vehicles)
                    {
                        Console.WriteLine(licencePlate);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void changeVehicleStatus()
        {
            string licencePlate;
            string input;
            bool toExit = false;

            licencePlate = getLicencePlate(out toExit);

            if (!toExit)
            {
                Console.WriteLine(k_GetVehicleStatus);
                while (true)
                {
                    input = Console.ReadLine();

                    if (checkIfExit(input))
                    {
                        return;
                    }

                    try
                    {
                        m_GarageManager.ChangeVehicleStatus(licencePlate, input);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine(k_VehicleChangedStatusSuccefully);
            }
        }

        private void inflateWheels()
        {
            string licencePlate;
            bool toExit;

            licencePlate = getLicencePlate(out toExit);
            if (!toExit)
            {
                m_GarageManager.InflateWheels(licencePlate);

                Console.WriteLine(k_VehicleInflatedSuccefully);
            }
        }

        private void fuelVehicle()
        {
            string licencePlate;
            string fuelType;
            string amountOfFuel;
            bool toExit;

            licencePlate = getLicencePlate(out toExit);

            if (!toExit)
            {
                Console.WriteLine(k_GetFuelType);
                Console.WriteLine("And then, " + k_GetAmountOfFuel);

                while (true)
                {
                    fuelType = Console.ReadLine();
                    amountOfFuel = Console.ReadLine();

                    if (checkIfExit(fuelType) || checkIfExit(amountOfFuel))
                    {
                        return;
                    }

                    try
                    {
                        m_GarageManager.FuelVehicle(licencePlate, fuelType, amountOfFuel);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine(k_VehicleFuledSuccefully);
            }
        }

        private void chargeVehicle()
        {
            string licencePlate;
            string input;
            bool toExit;

            licencePlate = getLicencePlate(out toExit);

            if (!toExit)
            {

                Console.WriteLine(k_GetAmountOfMinToCharge);
                while (true)
                {
                    input = Console.ReadLine();

                    if (checkIfExit(input))
                    {
                        return;
                    }

                    try
                    {
                        m_GarageManager.ChargeVehicle(licencePlate, input);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine(k_VehicleChargedSuccefully);
            }
        }

        private void getCompleteVehicleInfo()
        {

            string licencePlate;
            bool toExit;

            licencePlate = getLicencePlate(out toExit);
            if (!toExit)
            {
                Console.WriteLine(m_GarageManager.ToString(licencePlate));
            }
        }

        private bool checkIfExit(string i_Input)
        {
            bool isExit = false;

            if (i_Input.Equals("Exit") || i_Input.Equals("exit") || i_Input.Equals("EXIT"))
            {
                isExit = true;
            }

            return isExit;
        }
    }

    enum eGarageOperations
    {
        RegisterNewCar = 1,
        PullAllVehicles,
        ChangeVehicleStatus,
        InflateWheels,
        FuelVehicle,
        ChargeVehicle,
        CompleteVehicleInfo,
        Exit
    }
}
