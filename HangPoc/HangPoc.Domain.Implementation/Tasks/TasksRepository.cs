using System;
using System.Linq;

namespace HangPoc.Domain.Tasks {

    public class TasksRepository : ITasksRepository, IDisposable {

        private bool _disposed;

        private TasksContext _context;

        public TasksRepository() {
            _context = new TasksContext();
        }

        public Task Add(Task model) {

            if (model.Id == Guid.Empty || model.Id == null) {
                model.Id = Guid.NewGuid();
            }

            if (model.CreatedUtc == null) {
                model.CreatedUtc = DateTime.UtcNow;
            }

            var retVal = _context.Tasks.Add(model);
            _context.Entry(retVal).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();

            return retVal;
        }

        public IQueryable<Task> All() {

            return _context.Tasks;
        }

        public void Delete(Guid id) {

            var domain = FindById(id);
            _context.Tasks.Remove(domain);
            _context.Entry(domain).State = System.Data.Entity.EntityState.Deleted;

            _context.SaveChanges();
        }

        public Task FindById(Guid id) {

            return _context.Tasks.Find(id);
        }

        public Task Update(Task model) {

            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return model;
        }

        #region Disposable Impl
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) return;

            if (disposing) {
                _context.Dispose();
                _context = null;
            }

            _disposed = true;
        }

        ~TasksRepository() {
            Dispose(false);
        } 
        #endregion
    }
}
