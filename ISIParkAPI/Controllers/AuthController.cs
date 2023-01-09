using ISIParkAPI.Data;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    /// <summary>
    /// Authentication controller, this class is responsible for creating user and their login, with the tokens
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Create a instance of Interface User
        /// </summary>
        private readonly IUserRepository _userRepository;
        private MySQLConfiguration _connectionString;

       
        static UserDTO user = new UserDTO();

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="userRepository"></param>
        /// <param name="connectionString"></param>
        public AuthController(IConfiguration configuration, IUserRepository userRepository, MySQLConfiguration connectionString)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// Methods that inserts a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> InsertUser([FromBody]UserDTO request)
        {
            if (request == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            request.PasswordHash = passwordHash;
            request.PasswordSalt = passwordSalt;

            var inserted = await _userRepository.InsertUser(request);
            return Created("created", inserted);
        }

        /// <summary>
        /// Methods for a user to log in and return the respective token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin request)
        {
            if (!_userRepository.GetUserByEm(request.Email))
                return BadRequest("User not found!");

            var ph = _userRepository.GetUserByPasswordh(request.Email);
            var ps = _userRepository.GetUserByPasswords(request.Email);
            Console.WriteLine(ph);

            if (!VerifyPasswordHash(request.Password, ph, ps))
                return BadRequest("Wrong Password!");

            user = await _userRepository.GetUserByEmail(request.Email);

            if((user.Email == "admin") && (user.Password == "admin"))
            {
                string tokenA = CreateTokenAdmin(user);
                return Ok(tokenA);
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        /// <summary>
        /// Private method for creating the admin token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateTokenAdmin(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        /// <summary>
        /// Private method for creating a user's token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {         
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        /// <summary>
        /// Auxiliary method for the creation of the PasswordHash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Auxiliary method for the verification of the PasswordHash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
