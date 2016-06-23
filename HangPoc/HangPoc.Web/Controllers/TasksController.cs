using HangPoc.Web.Models;
using HangPoc.Web.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HangPoc.Web.Controllers {

    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController {

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll() {

            var retVal = new List<TaskViewModel>();

            using (var svc = new TasksService()) {

                retVal = svc.All();
            }

            return Ok(retVal);
        }

        [Route("randomize")]
        [HttpGet]
        public IHttpActionResult CreateRandomTasks() {

            var retVal = new List<TaskViewModel>();

            using (var svc = new TasksService()) {

                var rnd = new Random();

                for (int i = 0; i < 10; i++) {

                    var newTask = svc.Create(new TaskViewModel {
                        CreatedUtc = DateTime.UtcNow,
                        ExpiresAtUtc = DateTime.UtcNow.AddMinutes(rnd.Next(1, 5)),
                        IsExpired = false
                    });

                    retVal.Add(newTask);
                }
            }

            return Ok(retVal);
        }
    }
}