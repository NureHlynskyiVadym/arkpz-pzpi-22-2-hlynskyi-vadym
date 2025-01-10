using LevelUp.Models;
using System.Collections.Generic;

namespace LevelUp.Interfaces
{
    public interface IGroupRepository
    {
        ICollection<Group> GetGroups();
        ICollection<User> GetUsersByGroupId(int groupId);

        ICollection<Group> GetGroupsByUserId(int userId);
        Group GetGroupById(int id);
        bool AddGroup(Group group);
        bool DeleteGroup(int id);
        bool UpdateGroup(Group group);
        bool AddUserToGroup(int groupId, int userId);

        bool Save();
    }
}