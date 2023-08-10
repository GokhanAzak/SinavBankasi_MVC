﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinavBankasi.Models
{
    public class ChoiceModel
    {
        public int ChoiceId { get; set; }
        public string IsChecked { get; set; }
    }
    public class AnswerModel
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }

        public Guid Token { get; set; }

        public List<ChoiceModel> UserChoices { get; set; }
        public string Answer { get; set; }
        public string Direction  { get; set; }


        public List<int> UserSelectId
        {
            get
            {
                return UserChoices == null ? new List<int>() :
                    UserChoices.Where(x => x.IsChecked == "on" || "true".Equals(x.IsChecked, StringComparison.InvariantCultureIgnoreCase))
                    .Select(x => x.ChoiceId)
            .ToList();

            }
        }

    }
}