using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;
using Workspace.Poc.Ado.Service.Exceptions;

namespace Workspace.Poc.Ado.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        public UserService(IUserRepo userRepo, ITokenGenerator tokenGenerator, IMapper mapper)
        {
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _userRepo.GetAllUser();
            return result;
        }

        public async Task<String> AddUser(RegisterPayload user)
        {
            User newUser = _mapper.Map<User>(user);
            using (var hmac = new HMACSHA512())
            {
                newUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                newUser.Hashkey = hmac.Key;
            }
            await _userRepo.AddUser(newUser);
            return "Employee Added Successfully";
        }

        public async Task<LoginResponse> GetByEmail(LoginPayload user)
        {
            var existingUser = await _userRepo.GetByEmail(user.Email);
            if (existingUser.Email == user.Email)
            {
                var hmac = new HMACSHA512(existingUser.Hashkey);
                var enteredPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                for (int i = 0; i < enteredPassword.Length; i++)
                {
                    if (enteredPassword[i] != existingUser.Password[i])
                        throw new NotFound("The user name or password incorrect");
                }
                var Token = _tokenGenerator.GenerateToken(existingUser);
                LoginResponse response = new LoginResponse();
                response.Token = Token;
                return response;
            }
            throw new NotFound("The user name is not found");
        }
    }
}
