using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Comment : Entity
    {
        [Required]
        public string CommentText { get; protected set; }
        [Required]
        public DateTime CreatedAt { get; protected set; }
        [Required]
        public Guid CommenterId { get; protected set; }
        [Required]
        public Guid ProjectId { get; protected set; }

        public virtual User Commenter { get; set; }
        public virtual Project Project { get; set; }

        protected Comment()
        {

        }

        public Comment(Guid id, string commentText, bool delete, User user, Project project)
        {
            Id = id;
            CommenterId = user.Id;
            ProjectId = project.Id;
            CreatedAt = DateTime.UtcNow;

            SetCommentText(commentText);
        }  
       
        private void SetCommentText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ForbiddenValueException($"Comment with id {Id} can not have an empty text");
            }
            CommentText = text;
        }

        public static Comment Delete(Comment comment)
        {
            comment.Deleted = true;
            return comment;  
        }
    }
}
