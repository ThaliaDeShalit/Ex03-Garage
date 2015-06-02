using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // this class creates the vehicles, and the only class that needs to be changed to add a vehicle
    internal static class VehicleFactory
    {
        private const float k_MaxFuelCapacityMotorcycle = 8f;
        private const float k_MaxBatteryCapacityMotorcycle = 1.2f;
        private const float k_MaxFuelCapacityCar = 35f;
        private const float k_MaxBatteryCapacityCar = 2.2f;
        private const float k_MaxFuelCapacityTruck = 170f;
        private const float k_MaxAirPressureCarAndElectricMotorcycle = 31f;
        private const float k_MaxAirPressureFuelMotorcycle = 34f;
        private const float k_MaxAirPressureTruck = 25f;

        private static readonly int r_AmountOfVehicleTypes = Enum.GetValues(typeof(eVehicleType)).Length;
        
        // Creates an empty vehicle to be filled by the user
        internal static Vehicle CreateVehicle(string i_VehicleType) {
            Vehicle newVehicle = null;
            PowerSource newPowerSource = null;

            eVehicleType vehicleType = parseString(i_VehicleType);

            switch (vehicleType)
            {
                case eVehicleType.FueledCar:
                    newPowerSource = new FuelTank(eFuelType.Octan96, k_MaxFuelCapacityCar);
                    newVehicle = new Car(newPowerSource);
                    break;
                case eVehicleType.ElectricCar:
                    newPowerSource = new Battery(k_MaxBatteryCapacityCar);
                    newVehicle = new Car(newPowerSource);
                    break;
                case eVehicleType.FueledMotorcycle:
                    newPowerSource = new FuelTank(eFuelType.Octan98, k_MaxFuelCapacityMotorcycle);
                    newVehicle = new Motorcycle(newPowerSource, k_MaxAirPressureFuelMotorcycle);
                    break;
                case eVehicleType.ElecticMotorcycle:
                    newPowerSource = new Battery(k_MaxBatteryCapacityMotorcycle);
                    newVehicle = new Motorcycle(newPowerSource, k_MaxAirPressureCarAndElectricMotorcycle);
                    break;
                case eVehicleType.Truck:
                    newPowerSource = new FuelTank(eFuelType.Soler, k_MaxFuelCapacityTruck);
                    newVehicle = new Truck(newPowerSource);
                    break;
            }

            return newVehicle;
        }

        // parses the string represantation of the enum
        private static eVehicleType parseString(string i_Input)
        {
            int vehicleTypeInInt;
            eVehicleType vehicleType;

            if (int.TryParse(i_Input, out vehicleTypeInInt))
            {
                if (vehicleTypeInInt > 0 && vehicleTypeInInt <= r_AmountOfVehicleTypes)
                {
                    vehicleType = (eVehicleType)vehicleTypeInInt;
                }
                else
                {
                    throw new FormatException("Number does not correspond to any vehicle type");
                }
            } else {
                throw new FormatException("Input not a digit");
            }

            return vehicleType;
        }
    }

    internal enum eVehicleType
    {
        FueledCar = 1,
        ElectricCar,
        FueledMotorcycle,
        ElecticMotorcycle,
        Truck, 
    }
}
