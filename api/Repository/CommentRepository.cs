using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
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

        public async Task<Comment?> GetCommentById(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if(comment ==null)
            return null;

            return comment;
        }
      
        public async Task<Comment?> EditCommentById(int id, CommentUpdateDTO commentUpdateDTO)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if(comment == null)
            return null;

            comment.Title = commentUpdateDTO.Title;
            comment.Content = commentUpdateDTO.Content;

            await _context.SaveChangesAsync();

            return comment;

        }
    }
}