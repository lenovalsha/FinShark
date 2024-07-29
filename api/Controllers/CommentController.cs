using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase //Make sure to add this base before adding the annotation on the top
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewComment([FromBody] CreateCommentDto createCommentDto)
        {
                var comment = createCommentDto.ToCreateCommentDto();
                await _commentRepo.CreateCommentAsync(comment);

            return CreatedAtAction(nameof(GetCommentById), new {id = comment.Id}, comment.ToCommentDto());

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            //turn the comments that we get from our database and turn them into dtos
            var commentDto = comments.Select(s => s.ToCommentDto());
             return Ok(commentDto);
        }
       [HttpGet("{id}")]
       public async Task<IActionResult> GetCommentById([FromRoute] int id)
       {
        var comment = await _commentRepo.GetCommentById(id);
        if(comment == null)
        return NotFound();

        return Ok(comment.ToCommentDto());
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] CommentUpdateDTO commentUpdateDTO)
       {
         var commentModel = await _commentRepo.EditCommentById(id, commentUpdateDTO);

         if(commentModel == null)
         return NotFound();

        return Ok(commentModel.ToCommentDto());

       }
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteAsync([FromRoute]int id)
       {
            var comment = await _commentRepo.DeleteAsync(id);

            if(comment == null)
            return NotFound();

            return Ok(comment.ToCommentDto());
       }
    }

}