using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, Dictionary<string, object> i_VehicleProporties)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar:
                    newVehicle = new FueledCar((string)i_VehicleProporties["Model"], (string)i_VehicleProporties["Licence Plate"], (string)i_VehicleProporties["Wheel Manufctor Name"], (eCarColor)i_VehicleProporties["Car Color"], (eNumOfCarDoors)i_VehicleProporties["Amount Of Doors"]);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar((string)i_VehicleProporties["Model"], (string)i_VehicleProporties["Licence Plate"], (string)i_VehicleProporties["Wheel Manufctor Name"], (eCarColor)i_VehicleProporties["Car Color"], (eNumOfCarDoors)i_VehicleProporties["Amount Of Doors"]);
                    break;
                case eVehicleType.FueledMotorcycle:
                    newVehicle = new FueledMotorcycle((string)i_VehicleProporties["Model"], (string)i_VehicleProporties["Licence Plate"], (string)i_VehicleProporties["Wheel Manufctor Name"], (eLicenceType)i_VehicleProporties["Licence Type"], (int)i_VehicleProporties["Engine Volume"]);
                    break;
                case eVehicleType.ElecticMotorcycle:
                    newVehicle = new ElectricMotorcycle((string)i_VehicleProporties["Model"], (string)i_VehicleProporties["Licence Plate"], (string)i_VehicleProporties["Wheel Manufctor Name"], (eLicenceType)i_VehicleProporties["Licence Type"], (int)i_VehicleProporties["Engine Volume"]);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck((string)i_VehicleProporties["Model"], (string)i_VehicleProporties["Licence Plate"], (string)i_VehicleProporties["Wheel Manufctor Name"], (bool)i_VehicleProporties["Is Carrying Hazardous Materials"], (float)i_VehicleProporties["Current Carry Weight"]);
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
}
