using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private const int k_AmountOfWheels = 2;
        private readonly float r_MaxAirPressure;

        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        internal Motorcycle(string i_Model, string i_LicenceNumber, PowerSource i_PowerSource, string i_WheelManufactorName, float i_MaxAirPressure, float i_CurrentAirPressure, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_Model, i_LicenceNumber, i_PowerSource)
        {
            InitializeWheels(i_WheelManufactorName, r_MaxAirPressure, i_CurrentAirPressure, k_AmountOfWheels);
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
            r_MaxAirPressure = i_MaxAirPressure;
            m_NumOfExtraProperties = 2;
        }

        internal Motorcycle(PowerSource i_PowerSource, float i_MaxAirPressure)
        {
            m_PowerSource = i_PowerSource;
            m_Wheels = new List<Wheel>();
            SetWheelsMaxAirPressure(i_MaxAirPressure, k_AmountOfWheels);
            m_NumOfExtraProperties = 2;
        }

        internal string ToString()
        {
            string str = string.Format(
@"{0}

Motorcycle properties:
Licence type - {1}
Engine volume - {2}", base.ToString(), m_LicenceType, m_EngineVolume.ToString());

            return str;
        }

        // Creates a Question object to be sent to the user. A different Question must be created
        // for each property in the motorcycle
        internal Question GetProperty(int i_PropertyNumber)
        {
            Question propertyQuestion = null;
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            // According to the index of the property, send to the corresponding method
            // to create the question
            switch (property)
            {
                case eProperties.LicenceType:
                    propertyQuestion = getLicenceTypeQuestion();
                    break;
                case eProperties.EngineVolume:
                    propertyQuestion = getEngineVolumeQuestion();
                    break;
            }

            return propertyQuestion;
        }

        private QuestionWithMultipleAnswers getLicenceTypeQuestion()
        {
            return new QuestionWithMultipleAnswers("Which licence type is your motorcycle?", Enum.GetValues(typeof(eLicenceType)));
        }

        private QuestionWithOneAnswer getEngineVolumeQuestion()
        {
            return new QuestionWithOneAnswer("What is your engine volume?");
        }

        protected enum eProperties
        {
            LicenceType = 1,
            EngineVolume
        }
    }

    public enum eLicenceType
    {
        A = 1,
        A2,
        AB,
        B1
    }
}
