using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMagicClient.Entities;

namespace UniversalMagicClient.Services
{
    public class BlogService : IBlogService
    {
        private List<Author> authors = new List<Author>();
        private List<Post> posts = new List<Post>();
        private List<SocialNetwork> sns = new List<SocialNetwork>();

        public BlogService()
        {
            Author Abc = new Author
            {
                Id = 1,
                Name = "abc",
                Bio = "Wrote many books",
                ImgUrl = "www.book.com/author/abc/img.jpg",
                ProfileUrl = "www.book.com/author/abc/profile.jpg"
            };
            Author Xyz = new Author
            {
                Id = 2,
                Name = "xyz",
                Bio = "Had many blogs",
                ImgUrl = "www.blog.com/blogger/xyz/img.jpg",
                ProfileUrl = "www.blog.com/blogger/xyz/profile.jpg"
            };
            authors.Add(Abc);
            authors.Add(Xyz);
            Comment comment1 = new Comment
            {
                Url = "https://#",
                Description = "Bla bla bla",
                Count = 1
            };
            Comment comment2 = new Comment
            {
                Url = "https://#",
                Description = "Bla bla bla",
                Count = 4
            };
            Rating rating1 = new Rating
            {
                Percent = 98,
                Count = 1
            };
            Rating rating2 = new Rating
            {
                Percent = 95,
                Count = 5
            };
            Post BookDesc = new Post
            {
                Id = 1,
                Title = "How to book",
                Description = "How to cook, except it's book",
                Date = DateTime.Today,
                Url = "www.book.com/author/abc/1",
                Author = Abc,
                Comments = new List<Comment>() { comment1 },
                Rating = rating1,
                Categories = new string[] { "Post Modern" }
            };
            Post BlogDesc = new Post
            {
                Id = 2,
                Title = "How to blog",
                Description = "You have other options",
                Date = DateTime.Today,
                Url = "www.blog.com/blogger/xyz/1",
                Author = Xyz,
                Comments = new List<Comment>() { comment2 },
                Rating = rating2,
                Categories = new string[] { "Happiness" }
            };
            posts.Add(BookDesc);
            posts.Add(BlogDesc);
            SocialNetwork sn1 = new SocialNetwork()
            {
                Author = Abc,
                NickName = "@abc",
                Url = "https://#"
            };
            SocialNetwork sn2 = new SocialNetwork()
            {
                Author = Abc,
                NickName = "@abc",
                Url = "https://#"
            };
            sns.Add(sn1);
            sns.Add(sn2);
        }
        public List<Author> GetAllAuthors()
        {
            return this.authors;
        }
        public Author GetAuthorById(int id)
        {
            return authors.Where(author => author.Id == id).FirstOrDefault<Author>();
        }
        public List<Post> GetPostsByAuthor(int id)
        {
            return posts.Where(post => post.Author.Id == id).ToList<Post>();
        }
        public List<SocialNetwork> GetSNsByAuthor(int id)
        {
            return sns.Where(sn => sn.Author.Id == id).ToList<SocialNetwork>();
        }
        
        public Author CreateAuthor(Author author)
        {
            this.authors.Add(author);
            return author;
        }

    }
}
