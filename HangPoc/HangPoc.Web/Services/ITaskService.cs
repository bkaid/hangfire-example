using HangPoc.Web.Models;
using System;
using System.Collections.Generic;

namespace HangPoc.Web.Services {

    public interface ITaskService {

        TaskViewModel FindById(Guid id);

        List<TaskViewModel> All();

        TaskViewModel Create(TaskViewModel model);

        TaskViewModel Expire(Guid id);

        List<TaskViewModel> FindTasksThatShouldBeExpired();

    }
}
