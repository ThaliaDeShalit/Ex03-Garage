using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private const float k_MaxFuelCapacityMotorcycle = 8f;
        private const float k_MaxBatteryCapacityMotorcycle = 1.2f;
        private const float k_MaxFuelCapacityCar = 35f;
        private const float k_MaxBatteryCapacityCar = 2.2f;
        private const float k_MaxFuelCapacityTruck = 170f;
        private const float k_MaxAirPressureCarAndElectricMotorcycle = 31f;
        private const float k_MaxAirPressureFuelMotorcycle = 34f;
        private const float k_MaxAirPressureTruck = 25f;
        
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, Dictionary<eVehiclePropertyType, object> i_VehicleProporties)
        {
            Vehicle newVehicle = null;
            PowerSource newPowerSource = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar:
                    newPowerSource = new FuelTank(eFuelType.Octan96, k_MaxFuelCapacityCar, (float) i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);
                    newVehicle = new Car((string)i_VehicleProporties[eVehiclePropertyType.Model], 
                        (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], 
                        newPowerSource,
                        (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName],
                        (float)i_VehicleProporties[eVehiclePropertyType.WheelAirPressure],
                        (eCarColor)i_VehicleProporties[eVehiclePropertyType.CarColor], 
                        (eAmountOfDoors)i_VehicleProporties[eVehiclePropertyType.AmountOfDoors]);
                    break;
                case eVehicleType.ElectricCar:
                    newPowerSource = new Battery(k_MaxBatteryCapacityCar, (float) i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);
                    newVehicle = new Car((string)i_VehicleProporties[eVehiclePropertyType.Model],
                        (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate],
                        newPowerSource,
                        (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName],
                        (float)i_VehicleProporties[eVehiclePropertyType.WheelAirPressure],
                        (eCarColor)i_VehicleProporties[eVehiclePropertyType.CarColor],
                        (eAmountOfDoors)i_VehicleProporties[eVehiclePropertyType.AmountOfDoors]);
                    break;
                case eVehicleType.FueledMotorcycle:
                    newPowerSource = new FuelTank(eFuelType.Octan98, k_MaxFuelCapacityMotorcycle, (float)i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);
                    newVehicle = new Motorcycle((string)i_VehicleProporties[eVehiclePropertyType.Model], 
                        (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate],
                        newPowerSource,
                        (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName],
                        (float)i_VehicleProporties[eVehiclePropertyType.WheelAirPressure],
                        k_MaxAirPressureFuelMotorcycle,
                        (eLicenceType)i_VehicleProporties[eVehiclePropertyType.LicenceType], 
                        (int)i_VehicleProporties[eVehiclePropertyType.EngineVolume]);
                    break;
                case eVehicleType.ElecticMotorcycle:
                    newPowerSource = new Battery(k_MaxBatteryCapacityMotorcycle, (float)i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);
                    newVehicle = new Motorcycle((string)i_VehicleProporties[eVehiclePropertyType.Model],
                        (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate],
                        newPowerSource,
                        (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName],
                        (float)i_VehicleProporties[eVehiclePropertyType.WheelAirPressure],
                        k_MaxAirPressureCarAndElectricMotorcycle,
                        (eLicenceType)i_VehicleProporties[eVehiclePropertyType.LicenceType],
                        (int)i_VehicleProporties[eVehiclePropertyType.EngineVolume]);
                    break;
                case eVehicleType.Truck:
                    newPowerSource = new FuelTank(eFuelType.Soler, k_MaxFuelCapacityTruck, (float)i_VehicleProporties[eVehiclePropertyType.PowerSourceCapacity]);
                    newVehicle = new Truck((string)i_VehicleProporties[eVehiclePropertyType.Model], 
                        (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate],
                        newPowerSource,
                        (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName],
                        (float)i_VehicleProporties[eVehiclePropertyType.WheelAirPressure],
                        (bool)i_VehicleProporties[eVehiclePropertyType.CarryingHazardousMaterials], 
                        (float)i_VehicleProporties[eVehiclePropertyType.CarryWeight]);
                    break;
            }

            return newVehicle;
        }
    }

    public enum eVehicleType
    {
        FueledCar = 1,
        ElectricCar,
        FueledMotorcycle,
        ElecticMotorcycle,
        Truck
    }

    public enum eVehiclePropertyType
    {
        Model = 1,
        LicencePlate, 
        PowerSourceCapacity,
        WheelManuctorName,
        WheelAirPressure,
        CarColor,
        AmountOfDoors,
        LicenceType,
        EngineVolume,
        CarryingHazardousMaterials,
        CarryWeight,
    }
}
