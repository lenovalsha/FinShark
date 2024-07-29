using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
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

        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            //turn the comments that we get from our database and turn them into dtos
            var commentDto = comments.Select(s => s.ToCommentDto());

        }
    }
}