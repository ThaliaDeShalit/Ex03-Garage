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
    }
}
