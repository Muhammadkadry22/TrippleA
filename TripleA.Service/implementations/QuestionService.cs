﻿using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;


namespace TripleA.Service.implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService fileService;

        public QuestionService(IUnitOfWork unitOfWork, IFileService fileService)
        {

            _unitOfWork = unitOfWork;
            this.fileService = fileService;
        }
        public async Task<string> AddQuestion(Question question, IFormFile file)
        {

            var fileUrl = await fileService.UploadFile("Question", file);

            fileService.SetQuestionFilePath(fileUrl, question);

            await _unitOfWork.Questions.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<string> DeleteAsync(Question question)
        {
            var trans = _unitOfWork.Questions.BeginTransaction();
            try
            {
                _unitOfWork.Questions.Delete(question);
                await _unitOfWork.SaveChangesAsync();
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Question question)
        {
            try
            {
                _unitOfWork.Questions.Update(question);
                await _unitOfWork.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }


        public async Task<Question> GetByIDAsync(int id)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            return question;
        }

        //public async Task<Question> GetQuestionWithAnswersAndCommentsAsync(int questionId, int answersLimit, int commentsLimit)
        //{
        //    var questions = await _unitOfWork.Questions.GetByIdAsync(questionId);
        //}
    }
}
