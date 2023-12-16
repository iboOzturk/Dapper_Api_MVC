﻿using RealEstate_Dapper_Api.DTOs.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();              
      
        void CreateToDoList(CreateToDoListDto createToDoListDto);
        void DeleteToDoList(int id);
        void UpdateToDoList(UpdateToDoListDto updateToDoListDto);
    }
}
