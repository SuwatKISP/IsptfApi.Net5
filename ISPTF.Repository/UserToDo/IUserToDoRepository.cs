using ISPTF.Models.UserToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Repository.UserToDo
{
    public interface IUserToDoRepository
    {
        public Task<Models.UserToDo.UserToDo> UpsertAsync(UserToDoCreate userToDoCreate, int applicationUserId);
        public Task<Models.UserToDo.UserToDo> GetAsync(int userToDoId);
        public Task<List<Models.UserToDo.UserToDo>> GetAllByUserIdAsync(int applicationUserId, bool isComplete);
        public Task<int> DeleteAsync(int userToDoId);

    }
}
