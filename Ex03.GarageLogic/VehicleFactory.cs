using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, Dictionary<eVehiclePropertyType, object> i_VehicleProporties)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar:
                    newVehicle = new FueledCar((string)i_VehicleProporties[eVehiclePropertyType.Model], (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName], (eCarColor)i_VehicleProporties[eVehiclePropertyType.CarColor], (eNumOfCarDoors)i_VehicleProporties[eVehiclePropertyType.AmountOfDoors]);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar((string)i_VehicleProporties[eVehiclePropertyType.Model], (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName], (eCarColor)i_VehicleProporties[eVehiclePropertyType.CarColor], (eNumOfCarDoors)i_VehicleProporties[eVehiclePropertyType.AmountOfDoors]);
                    break;
                case eVehicleType.FueledMotorcycle:
                    newVehicle = new FueledMotorcycle((string)i_VehicleProporties[eVehiclePropertyType.Model], (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName], (eLicenceType)i_VehicleProporties[eVehiclePropertyType.LicenceType], (int)i_VehicleProporties[eVehiclePropertyType.EngineVolume]);
                    break;
                case eVehicleType.ElecticMotorcycle:
                    newVehicle = new ElectricMotorcycle((string)i_VehicleProporties[eVehiclePropertyType.Model], (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName], (eLicenceType)i_VehicleProporties[eVehiclePropertyType.LicenceType], (int)i_VehicleProporties[eVehiclePropertyType.EngineVolume]);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck((string)i_VehicleProporties[eVehiclePropertyType.Model], (string)i_VehicleProporties[eVehiclePropertyType.LicencePlate], (string)i_VehicleProporties[eVehiclePropertyType.WheelManuctorName], (bool)i_VehicleProporties[eVehiclePropertyType.CarryingHazardousMaterials], (float)i_VehicleProporties[eVehiclePropertyType.CarryWeight]);
                    break;
            }

            return newVehicle;
        }
    }

    public enum eVehicleType
    {
        FueledCar,
        ElectricCar,
        FueledMotorcycle,
        ElecticMotorcycle,
        Truck
    }

    public enum eVehiclePropertyType
    {
        Model,
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
