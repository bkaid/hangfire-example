using HangPoc.Web.Services;

namespace HangPoc.Web.Jobs {

    public class ExpireTasks {

        public static void Execute() {
            
            using (var svc = new TasksService()) {

                var expireList = svc.FindTasksThatShouldBeExpired();

                foreach(var t in expireList) {
                    svc.Expire(t.Id);
                }
            }
        }
    }
}