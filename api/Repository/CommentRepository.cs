using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository //MAKE SURE TO INHERET THE INTERFACE
    {
        
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
      

       

        public async Task<Comment?> GetCommentById(int Id)
        {
             var comment = await _context.Comments.FindAsync(Id);
            if(comment == null)
            return null;

            return comment;
        }
    }
}