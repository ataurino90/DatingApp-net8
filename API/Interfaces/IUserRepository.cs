using System;
using API.DTOs;
using API.Entities;
using API.Helpers;
using AutoMapper.Execution;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdASync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    //Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    Task<MemberDto?> GetMemberAsync(string username);
}
