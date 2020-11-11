using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.Payees_Expense;
using SplitwiseApp.Repository.Payers_Expense;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public class MockUser : IUser
    {

        #region private variables
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IPayeeExpenses _payees;
        private readonly IPayersExpenses _payers;
        #endregion

        #region public variables

        public float payeeShare = 0;
        public float receiverShare = 0;
        public float settlementShare = 0;
        public float receivedSettlementShare = 0;
        #endregion

        #region constructor
        public MockUser()
        {

        }
        public MockUser(AppDbContext context, UserManager<ApplicationUser> userManager,IMapper mapper,
             IConfiguration configuration,IPayeeExpenses payees,IPayersExpenses payers)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _payees = payees;
            _payers = payers;
          
        }

        #endregion

        #region public methods
        public async Task<IdentityResult> AddUser(signUpDTO user)
        {
             var users = new ApplicationUser { UserName = user.Email, Email = user.Email, Name = user.Name};
             return await _userManager.CreateAsync(users, user.Password);
            

        }
        public ActionResult<UserDTO> GetUserById(string userId)
        {
            
            return _mapper.Map<UserDTO>(_context.Users.Where(u => u.Id==userId).FirstOrDefault());
            
        }

        public async Task<ActionResult<UserDTO>> GetUserByEmailId(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);

        }
        public IEnumerable<UserDTO> GetUsers()
        {
            
             return _mapper.Map<IEnumerable<UserDTO>>(_context.Users);

        }
        public async Task<string> Login(LoginDTO users)
        {
             var user = await _userManager.FindByNameAsync(users.Email);
             if (user != null && await _userManager.CheckPasswordAsync(user, users.Password))
             {
                 var userRoles = await _userManager.GetRolesAsync(user);

                 var authClaims = new List<Claim>
                 {

                     new Claim("name", user.UserName),
                     new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 };

                 foreach (var userRole in userRoles)
                 {

                     authClaims.Add(new Claim("role", userRole));
                     authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                 }

                 var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                 var token = new JwtSecurityToken(
                     issuer: _configuration["JWT:ValidIssuer"],
                     audience: _configuration["JWT:ValidAudience"],
                     expires: DateTime.Now.AddHours(3),
                     claims: authClaims,
                     signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                     );
                 var result = new JwtSecurityTokenHandler().WriteToken(token);
                 return result;
             }
             return null;

        }

        public async Task<IdentityResult> UpdateProfile(UserDTO user)
        {
             ApplicationUser u = await _userManager.FindByIdAsync(user.Id);
             u.Email = user.Email;
             u.Name = user.Name;
             u.Balance = user.Balance;

             return await _userManager.UpdateAsync(u);

        }

        public bool UserExists(string userId)
        {
            var u = _userManager.FindByIdAsync(userId);
            if (u == null)
            {
                return false;
            }
            else
                return true;
            
         }

        public async Task<IdentityResult> GetBalanceByUserId(string userId)
        {
            ApplicationUser u = await _userManager.FindByIdAsync(userId);
            var payees = _context.payees_Expenses.Where(p => p.payerId == userId);
            var receivers = _context.payees_Expenses.Where(r => r.receiverId == userId);
            var settled = _context.settlement.Where(s => s.payerId == userId);
            var receiverSettled = _context.settlement.Where(s => s.receiverId == userId);

            foreach(var p in payees)
            {
                 payeeShare =payeeShare+ p.Share;
            }
            foreach(var r in receivers)
            {
                receiverShare = receiverShare + r.Share;
            }
            foreach(var s in settled)
            {
                settlementShare = settlementShare + s.Amount;
            }
            foreach(var sr in receiverSettled)
            {
                receivedSettlementShare = receivedSettlementShare + sr.Amount;   
            }
            var totalBalance = (payeeShare+receivedSettlementShare) - (settlementShare + receiverShare);
            u.Balance = totalBalance;
            return await _userManager.UpdateAsync(u);
        }

        #endregion
    }
}
