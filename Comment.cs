using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Comment
    {
        [Required]
        public Guid Id { get; protected set; }
        [Required]
        public string Text { get; protected set; }
        [Required]
        public DateTime Date { get; protected set; }
        [Required]
        public bool Delete { get; protected set; }
        [Required]
        public Guid CommentatorId { get; protected set; }
        [Required]
        public Guid ProjectId { get; protected set; }

        protected Comment()
        {

        }

        public Comment(Guid id, string text, DateTime date, Guid comentatorId, Guid projectId, bool delete)
        {
            Id = id;

            SetText(text);
            SetDate(date);
            SetCommentatorId(comentatorId);
            SetProjectId(projectId);
            SetDelete(delete);
        }
        private void SetDate(DateTime dateofComment)
        {
            if (dateofComment == default(DateTime))
            {
                throw new ForbiddenValueException($"Comment with id {Id} can not have default create date.");
            }
            Date = dateofComment;
        }
        private void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ForbiddenValueException($"Comment with id {Id} can not have an empty text");
            }
            Text = text;
        }
    }
}
