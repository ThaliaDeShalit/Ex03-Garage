using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        protected string m_Model;
        protected string m_LicenceNumber;
        protected float m_PercentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;

        public virtual Vehicle(string i_Model, string i_LicenceNumber)
        {
            m_Model = i_Model;
            m_LicenceNumber = i_LicenceNumber;
        }
    }
}
