using System.ComponentModel.DataAnnotations;

namespace BlazorApp1Test
{
    public class BlogPost
    {
		[Required]
        public string Title { get; set; }

		[Required]
		[StringLength(16, ErrorMessage = "The slug is too long (16 character limit).")]
        public string Slug { get; set; }

		[Required]
        public string Content { get; set; }
    }
}