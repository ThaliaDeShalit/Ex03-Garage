﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_AmountOfWheels = 16;
        private const float k_MaxWheelAirPressure = 25f;
        private const float K_FuelTankMaxFuelAmount = 170f;
        private const eFuelType k_FuelType = eFuelType.Soler;

        private bool m_IsCarryingHazardousMaterials;
        private float m_CurrentCarryWeight;

        private FuelTank m_FuelTank;

        public Truck(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource, string i_WheelManufactorName, float i_CurrentAirPressure, bool i_IsCarryingHazardousMaterials, float i_CurrentCarryWeight)
            : base(i_Model, i_LicenceNumber, i_PowerSource)
        {
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, i_CurrentAirPressure, k_AmountOfWheels);
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_CurrentCarryWeight = i_CurrentCarryWeight;
            m_NumOfExtraProperties = 2;
        }

        internal Truck(PowerSource i_PowerSource)
        {
            m_PowerSource = i_PowerSource;
            m_Wheels = new List<Wheel>();
            SetWheelsMaxAirPressure(k_MaxWheelAirPressure, k_AmountOfWheels);
            m_NumOfExtraProperties = 2;
        }

        public string ToString()
        {
            string isCarryingHazardousMaterials;

            if (m_IsCarryingHazardousMaterials)
            {
                isCarryingHazardousMaterials = "yes";
            }
            else
            {
                isCarryingHazardousMaterials = "no";
            }
            
            string str = string.Format(
@"{0}

Truck properties:
Carrying hazardous materials - {1}
Current carry weight - {2}", base.ToString(), isCarryingHazardousMaterials, m_CurrentCarryWeight.ToString());

            return str;
        }

        internal Question GetProperty(int i_PropertyNumber)
        {
            Question propertyQuestion = null;
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            switch (property)
            {
                case eProperties.IsCarryingHazardousMaterials:
                    propertyQuestion = getIsCarryingHazardousMaterialsQuestion();
                    break;
                case eProperties.CurrentCarryWeight:
                    propertyQuestion = getCurrentCarryWeightQuestion();
                    break;
            }

            return propertyQuestion;
        }

        private QuestionWithOneAnswer getIsCarryingHazardousMaterialsQuestion()
        {
            return new QuestionWithOneAnswer("Are you carrying hazardous materials?");
        }

        private QuestionWithOneAnswer getCurrentCarryWeightQuestion()
        {
            return new QuestionWithOneAnswer("What is your truck's current wheight?");
        }

        protected enum eProperties
        {
            IsCarryingHazardousMaterials = 1,
            CurrentCarryWeight
        }
    }
}
