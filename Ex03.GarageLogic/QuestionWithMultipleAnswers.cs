using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class QuestionWithMultipleAnswers : Question
    {
        private string[] m_Options;

        internal QuestionWithMultipleAnswers(string i_Question, Array i_Options)
            : base(i_Question)
        {
            m_Options = new string[i_Options.Length];
            for (int i = 0; i < i_Options.Length; i++)
            {
                m_Options[i] = splitCamelCase(i_Options.GetValue(i).ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= m_Options.Length; i++)
            {
                sb.Append(i + ": ");
                sb.Append(m_Options[i - 1]);
                sb.Append(Environment.NewLine);
            }

            string question = string.Format(
@"{0}
{1}", base.ToString(), sb.ToString());

            return question;
        }
    }
}
