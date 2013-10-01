using QandA.Core.Domain;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        SqlContext context = new SqlContext();
        GenericRepository<Question> questionRepository;

        public IGenericRepository<Question> QuestionsRepository
        {
            get
            {
                if (questionRepository == null)
                {
                    questionRepository = new GenericRepository<Question>(context);
                }
                return questionRepository;
            }
      
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
