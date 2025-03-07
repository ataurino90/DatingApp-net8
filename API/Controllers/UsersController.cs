using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]
    public class UsersController (IUserRepository userRepository,IMapper mapper): BaseApiController
    {
        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepository.GetMembersAsync();
            //_context.Users.ToListAsync();
            //var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);

            return Ok(users);
        }

        //[Authorize]
        [HttpGet("{username}")] // api/users/1
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await  userRepository.GetMemberAsync(username);                        

            if (user == null) return NotFound();

            return user;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return BadRequest("No user name found in token");
            var user = await userRepository.GetUserByUsernameAsync(username);
            if (user == null) return BadRequest("Could not find user");
            mapper.Map(memberUpdateDto, user);
            if (await userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Faild updated the user");
        }
    }
}
