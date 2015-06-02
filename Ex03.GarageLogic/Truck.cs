using System;
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

        public Truck(PowerSource i_PowerSource)
        {
            m_PowerSource = i_PowerSource;
            m_Wheels = new List<Wheel>();
            SetWheelsMaxAirPressure(k_MaxWheelAirPressure, k_AmountOfWheels);
            m_NumOfExtraProperties = Enum.GetValues(typeof(eProperties)).Length;
        }

        internal bool IsCarryingHazardousMaterials
        {
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }

        internal float CurrentCarryWeight
        {
            set
            {
                m_CurrentCarryWeight = value;
            }
        }

        public override string ToString()
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

        // Creates a Question object to be sent to the user. A different Question must be created
        // for each property in the truck
        internal override Question GetProperty(int i_PropertyNumber)
        {
            Question propertyQuestion = null;
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            // According to the index of the property, send to the corresponding method
            // to create the question
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

        internal override void SetProperty(int i_PropertyNumber, string i_PropertyValue)
        {
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            switch (property)
            {
                case eProperties.IsCarryingHazardousMaterials:
                    setIsCarryingHazardousMaterials(i_PropertyValue);
                    break;
                case eProperties.CurrentCarryWeight:
                    setCurrentCarryWeight(i_PropertyValue);
                    break;
            }
        }

        internal void setIsCarryingHazardousMaterials(string i_Input)
        {
            if (i_Input.Length == 1)
            {
                if (i_Input == "y" || i_Input == "Y")
                {
                    IsCarryingHazardousMaterials = true;
                }
                else if (i_Input == "n" || i_Input == "N")
                {
                    IsCarryingHazardousMaterials = false;
                }
                else
                {
                    throw new FormatException("Hazardous material property can either be true (y) or false (n)");
                }
            }
        }

        internal void setCurrentCarryWeight(string i_Input)
        {
            float parsedInput;

            if (float.TryParse(i_Input, out parsedInput))
            {
                if (parsedInput >= 0)
                {
                    CurrentCarryWeight = parsedInput;
                }
                else
                {
                    throw new FormatException("Current carry weight must be a non negtive value");
                }
            }
            else
            {
                throw new FormatException("Current carry weight must consist of float");
            }
        }

        protected enum eProperties
        {
            IsCarryingHazardousMaterials = 1,
            CurrentCarryWeight
        }
    }
}
