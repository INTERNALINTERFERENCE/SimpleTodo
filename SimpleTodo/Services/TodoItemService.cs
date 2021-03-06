﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTodo.Data;
using SimpleTodo.Models;

namespace SimpleTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationContext _context;

        public TodoItemService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
                .Where(x => x.IsDone == false)
                .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            
            _context.Items.Add(newItem);
            
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}