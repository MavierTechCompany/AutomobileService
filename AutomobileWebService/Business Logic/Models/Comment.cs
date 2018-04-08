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
        public string CommentText { get; protected set; }
        public int CommenterId { get; protected set; }
        public int ProjectId { get; protected set; }

        public virtual User Commenter { get; set; }
        public virtual Project Project { get; set; }

        protected Comment() { }

        public Comment(string commentText, User user,
            Project project) : base()
        {
            CommenterId = user.Id;
            ProjectId = project.Id;

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
    }
}
