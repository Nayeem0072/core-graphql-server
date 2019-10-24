using System.Collections.Generic;
using UniversalMagicClient.Entities;

namespace UniversalMagicClient.Services
{
    public interface IBlogService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        List<Post> GetPostsByAuthor(int id);
        List<SocialNetwork> GetSNsByAuthor(int id);
        Author CreateAuthor(Author author);

    }
}
