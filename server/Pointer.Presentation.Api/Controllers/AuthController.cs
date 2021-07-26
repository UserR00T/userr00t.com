using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pointer.Core.Domain.Models.DTOs;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;
using Pointer.Presentation.Api.Managers;
using SqlKata.Execution;

namespace Pointer.Presentation.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly Repository<User> _userRepository;

        private readonly TokenManager _tokenManager;

        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(Repository<User> userRepository, TokenManager tokenManager, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenManager = tokenManager;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public ActionResult<Dictionary<string, object>> Login([FromBody]LoginDto login)
        {
            var user = _userRepository.Query().Where("Username", login.Username).FirstOrDefault<User>();
            if (user == null)
            {
                return NotFound();
            }
            if (_passwordHasher.VerifyHashedPassword(user, user.Password, login.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized();
            }
            var token = _tokenManager.Generate(user.Id);
            return new Dictionary<string, object>()
            {
                ["user"] = user,
                ["token"] = token
            };
        }
    }
}