using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangPoc.Domain.Tasks {

    public interface ITasksRepository {

        IQueryable<Task> All();

        Task FindById(Guid id);

        Task Add(Task model);

        Task Update(Task model);

        void Delete(Guid id);
    }
}
