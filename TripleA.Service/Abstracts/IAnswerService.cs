﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IAnswerService
    {
        Task<string> AddAnswer(Answer question);
        void DownVote(Answer answer);
        Task<Answer> getAnswerById(int answerId);
        Task Upvote(Answer answer);
    }
}
