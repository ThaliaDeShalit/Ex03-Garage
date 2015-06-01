using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // This class will hold a question that is passed from the GarageManager to the GarageUIManager.
    // This way, the questions are created in a modular fashion but still in an accepted format so the
    // GarageUIManager can display the question properly to the user
    abstract class Question
    {
        // Holds the question
        protected string m_Question;

        internal Question(string i_Question)
        {
            m_Question = i_Question;
        }

        internal string ToString()
        {
            return m_Question;
        }

        // Used to create readable text from camel cased values of enums (example: AmountOfDoors => Amount Of Doors)
        protected string splitCamelCase(string i_CamelCasedString)
        {
            return System.Text.RegularExpressions.Regex.Replace(i_CamelCasedString, "([A-Z]|[0-9]+)", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
    }
}
