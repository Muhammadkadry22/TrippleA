﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Question.Commands.Models
{
    public class AddQuestionCommand : IRequest<Response<String>>
    {
        public string Description { get; set; }
        public string Title { get; set; }
        //public string Image { get; set; }
        public DateTime CreatedIn { get; set; }
        public int CategoryId { get; set; }
    }
}
