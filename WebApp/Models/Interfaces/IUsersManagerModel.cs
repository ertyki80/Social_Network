using System.Collections.Generic;

namespace WebApp.Models.Interfaces
{
    interface IUsersManagerModel
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserByLogin(string login);
        UserModel GetUserById(int id);
        void AddToFriend(int idFrom, int idTo);
        bool CreateUser(RegisterModel u);
        FullUserModel GetMyUserById(int id);
        int GetPathLenBetweenUsers(int id1, int id2);
        UserNeo4JModel GetPathBetweenUsers(int u1Id, int u2Id);
    }
}
