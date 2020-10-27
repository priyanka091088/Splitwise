using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.User
{
    public class MockUser : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MockUser()
        {

        }
        public MockUser(AppDbContext context, UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
          
        }
        public async Task<IdentityResult> AddUser(signUpDTO user)
        {
            var users = new ApplicationUser { UserName = user.Email, Email = user.Email, Name = user.Name, Balance = user.Balance };
            return await _userManager.CreateAsync(users, user.Password);
           
        }
        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
            
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_userManager.Users);
            //return _context.Users.ToList();
            
        }
        public Task<UserDTO> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProfile(ApplicationUser user)
        {
            ApplicationUser u = await _userManager.FindByIdAsync(user.Id);
            u.Email = user.Email;
            u.Name = user.Name;
            u.Balance = user.Balance;

            await _userManager.UpdateAsync(u);
          
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
    }
}
