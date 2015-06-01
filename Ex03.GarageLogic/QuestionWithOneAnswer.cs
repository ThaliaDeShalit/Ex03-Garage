using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // Used for questions with an open answer, such as entering a licence plate
    class QuestionWithOneAnswer : Question
    {
        public QuestionWithOneAnswer(string i_Question)
            : base(i_Question)
        {
            return;
        }
    }
}
