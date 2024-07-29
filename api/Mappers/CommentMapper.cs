using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commendModel)
        {
            return new CommentDto
            {
                Id = commendModel.Id,
                Title = commendModel.Title,
                Content = commendModel.Content,
                CreatedOn = commendModel.CreatedOn,
                StockId = commendModel.StockId
            };
        }
         public static Comment ToCreateCommentDto(this CreateCommentDto commendModel)
        {
            return new Comment
            {
                Title = commendModel.Title,
                Content = commendModel.Content,
                CreatedOn = commendModel.CreatedOn,
                StockId = commendModel.StockId
            };
        }
    }
}