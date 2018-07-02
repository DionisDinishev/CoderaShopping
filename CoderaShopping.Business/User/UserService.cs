using System;
using System.Collections.Generic;
using System.Linq;
using CoderaShopping.Business.Mappers;
using CoderaShopping.Business.Models;
using CoderaShopping.DataNHibernate;
using CoderaShopping.DataNHibernate.Repositories;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Services
{
    public interface IUserService
    {
        //CRUD
        UserViewModel GetById(Guid userId);
        IList<UserViewModel> GetAll();
        void AddUser(UserViewModel user);
        void Update(UserViewModel user);

        void Delete(UserViewModel user);

        //Search
        UserViewModel SearchById(Guid id);
        List<UserViewModel> SearchByName(string name);
        List<UserViewModel> SearchByEmail(string email);
        List<UserViewModel> SearchByPhone(string phone);

        List<UserViewModel> SearchByUserType(string userType);

        //Sort
        List<UserViewModel> OrderByName(bool ascendingOrder);
        List<UserViewModel> OrderByEmail(bool ascendingOrder);
        List<UserViewModel> OrderByPhone(bool ascendingOrder);
        List<UserViewModel> OrderByUserType(bool ascendingOrder);
        List<UserViewModel> GetUsersOnPage(int page, int size);
        //Count
        int GetUsersCount();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public UserViewModel GetById(Guid userId)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("USER NOT FOUND!");

            var mappedUser = user.MapToViewModel();

            _unitOfWork.Commit();

            return mappedUser;
        }

        public IList<UserViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var users = _userRepository.GetAll().Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();

            return users;
        }

        public void AddUser(UserViewModel user)
        {
            _unitOfWork.BeginTransaction();
            //TODO:ValidateUserType
            UserType userType = UserType.Undefined;
            if (user?.UserType?.Equals("Internal") == null)
            {
                userType = UserType.Undefined;
            }
            else if (user.UserType.Equals("Internal"))
            {
                userType = UserType.Internal;
            }
            else if (user.UserType.Equals("External"))
            {
                userType = UserType.External;
            }

            if (user != null)
            {
                var addUser = new User(new Guid(), user.Name, user.Email, user.Phone, userType);
                _userRepository.Add(addUser);
            }

            _unitOfWork.Commit();
        }

        public void Update(UserViewModel user)
        {
            _unitOfWork.BeginTransaction();
            UserType userType = UserType.External;
            if (user.UserType.Equals("Internal"))
            {
                userType = UserType.Internal;
            }

            var userUpdate = new User(user.Id, user.Name, user.Email, user.Phone, userType);


            _userRepository.Update(userUpdate);

            _unitOfWork.Commit();
        }

        public void Delete(UserViewModel user)
        {
            _unitOfWork.BeginTransaction();
            var userType = UserType.External;
            if (user.UserType.Equals("Internal"))
            {
                userType = UserType.Internal;
            }

            var userDelete = new User(user.Id, user.Name, user.Email, user.Phone, userType);

            _userRepository.Delete(userDelete);
            _unitOfWork.Commit();
        }

        public UserViewModel SearchById(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetById(id).MapToViewModel();
            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> SearchByName(string name)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => x.MapToViewModel())
                .ToList();

            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> SearchByEmail(string email)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Where(x => x.Email.Contains(email)).Select(x => x.MapToViewModel())
                .ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> SearchByPhone(string phone)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Where(x => x.Phone.Contains(phone)).Select(x => x.MapToViewModel())
                .ToList();

            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> SearchByUserType(string userType)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Select(x => x.MapToViewModel())
                .Where(x => x.UserType.Equals(userType)).ToList();

            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> OrderByName(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();

            var result = _userRepository.GetAll().OrderBy(x => x.Name).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();
            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> OrderByEmail(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().OrderBy(x => x.Email).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();
            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> OrderByPhone(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();

            var result = _userRepository.GetAll().OrderBy(x => x.Phone).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();

            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> OrderByUserType(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().OrderBy(x => x.UserType).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();
            _unitOfWork.Commit();
            return result;
        }

        public List<UserViewModel> GetUsersOnPage(int page, int size)
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Skip((page-1)*size).Take(size).Select(x => x.MapToViewModel()).ToList();
            _unitOfWork.Commit();
            return result;
        }

        public int GetUsersCount()
        {
            _unitOfWork.BeginTransaction();
            var result = _userRepository.GetAll().Count();
            _unitOfWork.Commit();
            return result;
        }
    }
}
