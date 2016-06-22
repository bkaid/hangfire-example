using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangPoc.Web.Models;
using HangPoc.Domain.Tasks;

namespace HangPoc.Web.Services {

    public class TasksService : ITaskService, IDisposable {

        private bool _disposed;
        private TasksRepository _repo;

        public TasksService() {
            _repo = new TasksRepository();
        }

        public List<TaskViewModel> All() {

            var retVal = new List<TaskViewModel>();
            var domain = _repo.All().ToList();

            foreach(var d in domain) {
                retVal.Add(Map(d));
            }

            return retVal;
        }

        public TaskViewModel Create(TaskViewModel model) {

            var domain = _repo.Add(new Task {
                ExpiresAtUtc = model.ExpiresAtUtc,
                IsExpired = model.IsExpired
            });

            return Map(domain);
        }

        public TaskViewModel Expire(Guid id) {

            var domain = _repo.FindById(id);

            domain.IsExpired = true;
            domain = _repo.Update(domain);

            return Map(domain);
        }

        public TaskViewModel FindById(Guid id) {

            var domain = _repo.FindById(id);

            return Map(domain);
        }

        public List<TaskViewModel> FindTasksThatShouldBeExpired() {

            var retVal = new List<TaskViewModel>();
            var domain = _repo.All()
                .Where(x => x.ExpiresAtUtc <= DateTime.UtcNow && x.IsExpired == false)
                .ToList();

            foreach (var d in domain) {
                retVal.Add(Map(d));
            }

            return retVal;
        }

        private static TaskViewModel Map(Task domain) {

            return new TaskViewModel {
                Id = domain.Id,
                CreatedUtc = domain.CreatedUtc,
                ExpiresAtUtc = domain.ExpiresAtUtc,
                IsExpired = domain.IsExpired
            };
        }

        #region Disposable Impl
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) return;

            if (disposing) {
                _repo.Dispose();
                _repo = null;
            }

            _disposed = true;
        }

        ~TasksService() {
            Dispose(false);
        }
        #endregion
    }
}