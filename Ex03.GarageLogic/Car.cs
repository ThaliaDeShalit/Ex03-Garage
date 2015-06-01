using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal const float k_MaxWheelAirPressure = 31;
        private const int k_AmountOfWheels = 4;

        private eCarColor m_CarColor;
        private eAmountOfDoors m_NumOfCarDoors;

        internal Car(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource, string i_WheelManufactorName, float i_CurrentAirPressure, eCarColor i_CarColor, eAmountOfDoors i_NumOfCarDoors)
            : base(i_Model, i_LicenceNumber, i_PowerSource)
        {
            InitializeWheels(i_WheelManufactorName, k_MaxWheelAirPressure, i_CurrentAirPressure, k_AmountOfWheels);
            m_CarColor = i_CarColor;
            m_NumOfCarDoors = i_NumOfCarDoors;
            m_NumOfExtraProperties = 2;
        }

        internal Car(PowerSource i_PowerSource)
        {
            m_PowerSource = i_PowerSource;
            m_Wheels = new List<Wheel>();
            SetWheelsMaxAirPressure(k_MaxWheelAirPressure, k_AmountOfWheels);
            m_NumOfExtraProperties = 2;
        }

        internal eCarColor CarColor
        {
            set
            {
                m_CarColor = value;
            }
        }

        internal eAmountOfDoors AmountOfDoors
        {
            set
            {
                m_NumOfCarDoors = value;
            }
        }

        public override string ToString()
        {
            string str = string.Format(
@"{0}

Car properties:
Car color - {1}
Number of doors - {2}", base.ToString(), m_CarColor, m_NumOfCarDoors);

            return str;
        }

        // Creates a Question object to be sent to the user. A different Question must be created
        // for each property in the car
        internal override Question GetProperty(int i_PropertyNumber)
        {
            Question propertyQuestion = null;
            eProperties property;

            // According to the index of the property, send to the corresponding method
            // to create the question
            property = (eProperties)i_PropertyNumber;
            switch (property)
            {
                case eProperties.CarColor:
                    propertyQuestion = getCarColorQuestion();
                    break;
                case eProperties.AmountOfDoors:
                    propertyQuestion = getAmountOfDoorsQuestion();
                    break;
            }

            return propertyQuestion;
        }

        private QuestionWithMultipleAnswers getCarColorQuestion()
        {
            return new QuestionWithMultipleAnswers("Which color is your car?", Enum.GetValues(typeof(eCarColor)));
        }

        private QuestionWithOneAnswer getAmountOfDoorsQuestion()
        {
            return new QuestionWithOneAnswer("How many doors do you have? (between 2 and 5)");
        }

        internal override void SetProperty(int i_PropertyNumber, string i_PropertyValue)
        {
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            switch (property)
            {
                case eProperties.CarColor:
                    setCarColor(i_PropertyValue);
                    break;
                case eProperties.AmountOfDoors:
                    setAmountOfDoors(i_PropertyValue);
                    break;
            }
        }

        internal void setCarColor(string i_Input)
        {
            int intRepresentationOfEnum;

            if (int.TryParse(i_Input, out intRepresentationOfEnum))
            {
                if (intRepresentationOfEnum > 0 && intRepresentationOfEnum < 5)
                {
                    CarColor = (eCarColor)intRepresentationOfEnum;
                }
                else
                {
                    throw new FormatException("Car color must be a digit corresponding to a car color");
                }
            }
            else
            {
                throw new FormatException("Car color must be a digit");
            }
        }

        internal void setAmountOfDoors(string i_Input)
        {
            int intRepresentationOfEnum;

            if (int.TryParse(i_Input, out intRepresentationOfEnum))
            {
                if (intRepresentationOfEnum > 0 && intRepresentationOfEnum < 5)
                {
                    AmountOfDoors = (eAmountOfDoors)intRepresentationOfEnum;
                }
                else
                {
                    throw new FormatException("Amount of doors must be a digit between 2 and 5");
                }
            }
            else
            {
                throw new FormatException("Amount of doors must be a digit");
            }
        }

        internal enum eProperties
        {
            CarColor = 1,
            AmountOfDoors
        }
    }

    internal enum eCarColor
    {
        Green = 1,
        Red,
        White,
        Black
    }

    internal enum eAmountOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
