using AutoMapper;
using BuisnessLogic.Concrete;
using DataTransfer.Models;
using System.Collections.Generic;
using WebApp.Models.Interfaces;

namespace WebApp.Models.Concrete
{
    public class UsersManagerModel : IUsersManagerModel
    {
        private readonly IMapper _mapper;

        public UsersManagerModel()
        {
            MapperConfiguration conf = new MapperConfiguration(
                       cfg => cfg.AddMaps(
                           typeof(UserDTO).Assembly,
                           typeof(UserNeo4JModel).Assembly,
                           typeof(FullUserModel).Assembly
                       )
                   );

            this._mapper = conf.CreateMapper();
        }
        public UsersManagerModel(IMapper mapper)
        {
            _mapper = mapper;

        }
        public void AddToFriend(int idFrom, int idTo)
        {
            UserManager manager = new UserManager();
            manager.CreateRelationship(idFrom, idTo);
        }

        public bool CreateUser(RegisterModel u)
        {
            UserManager manager = new UserManager();
            return manager.CreateUser(_mapper.Map<UserDTO>(u));
        }

        public List<UserModel> GetAllUsers()
        {
            UserManager manager = new UserManager();
            return _mapper.Map<List<UserModel>>(manager.GetAllUsers());
        }

        public FullUserModel GetMyUserById(int id)
        {
            UserManager manager = new UserManager();
            return _mapper.Map<FullUserModel>(manager.GetUserById(id));
        }

        public UserNeo4JModel GetPathBetweenUsers(int u1Id, int u2Id)
        {
            UserManager manager = new UserManager();
            var path = manager.GetPathBetweenUsers(u1Id, u2Id);
            var path_len = manager.GetPathLenBetweenUsers(u1Id, u2Id);
            var path_list = _mapper.Map<List<UserModel>>(path);
            return new UserNeo4JModel { UserFromId = u1Id, UserToId = u2Id, PathToUser = path_list, PathLen = path_len };
        }

        public int GetPathLenBetweenUsers(int id1, int id2)
        {
            UserManager manager = new UserManager();
            return manager.GetPathLenBetweenUsers(id1, id2);
        }

        public UserModel GetUserById(int id)
        {
            UserManager manager = new UserManager();
            return _mapper.Map<UserModel>(manager.GetUserById(id));
        }

        public UserModel GetUserByLogin(string login)
        {
            UserManager manager = new UserManager();
            return _mapper.Map<UserModel>(manager.GetUserByLogin(login));
        }
    }
}