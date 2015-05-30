using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        protected const int k_AmountOfWheels = 2;
        
        protected eLicenceType m_LicenceType;
        protected int m_EngineVolume;

        public Motorcycle(string i_Model, string i_LicenceNumber, eLicenceType i_LicenceType, int i_EngineVolume) : base(i_Model, i_LicenceNumber) {
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
        }
    }

    public enum eLicenceType
    {
        A,
        A2,
        AB,
        B1
    }
}
