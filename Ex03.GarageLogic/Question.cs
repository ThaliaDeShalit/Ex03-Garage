using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Question
    {
        protected string m_Question;

        internal Question(string i_Question)
        {
            m_Question = i_Question;
        }

        internal string ToString()
        {
            return m_Question;
        }

        protected string splitCamelCase(string i_CamelCasedString)
        {
            return System.Text.RegularExpressions.Regex.Replace(i_CamelCasedString, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
    }
}
