
using System;

namespace Blogging.DbModel.Dto
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CategoryName { get; set; }
    }
}