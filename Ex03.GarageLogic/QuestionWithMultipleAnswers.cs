using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class QuestionWithMultipleAnswers : Question
    {
        private string[] m_Options;

        internal QuestionWithMultipleAnswers(string i_Question, string[] i_Options)
            : base(i_Question)
        {
            m_Options = i_Options;
        }
    }
}
