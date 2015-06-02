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

        public Motorcycle(PowerSource i_PowerSource, float i_MaxAirPressure)
        {
            m_PowerSource = i_PowerSource;
            m_Wheels = new List<Wheel>();
            SetWheelsMaxAirPressure(i_MaxAirPressure, k_AmountOfWheels);
            m_NumOfExtraProperties = Enum.GetValues(typeof(eProperties)).Length;
        }

        internal eLicenceType LicenceType
        {
            set
            {
                m_LicenceType = value;
            }
        }

        internal int EngineVolume
        {
            set
            {
                m_EngineVolume = value;
            }
        }

        public override string ToString()
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
        internal override Question GetProperty(int i_PropertyNumber)
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

        internal override void SetProperty(int i_PropertyNumber, string i_PropertyValue)
        {
            eProperties property;

            property = (eProperties)i_PropertyNumber;
            switch (property)
            {
                case eProperties.LicenceType:
                    setLicenceType(i_PropertyValue);
                    break;
                case eProperties.EngineVolume:
                    setEngineVolume(i_PropertyValue);
                    break;
            }
        }

        internal void setLicenceType(string i_Input)
        {
            int intRepresentationOfEnum;

            if (int.TryParse(i_Input, out intRepresentationOfEnum))
            {
                if (intRepresentationOfEnum > 0 && intRepresentationOfEnum < 5)
                {
                    LicenceType = (eLicenceType)intRepresentationOfEnum;
                }
                else
                {
                    throw new FormatException("Licence type must be a digit corresponding to a licence type");
                }
            }
            else
            {
                throw new FormatException("Licence type must be a digit");
            }
        }

        internal void setEngineVolume(string i_Input)
        {
            int parsedInput;

            if (int.TryParse(i_Input, out parsedInput))
            {
                if (parsedInput > 0)
                {
                    EngineVolume = parsedInput;
                }
                else
                {
                    throw new FormatException("Engine volume must be positive value");
                }
            }
            else
            {
                throw new FormatException("Engine volume must consist of digits");
            }
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
