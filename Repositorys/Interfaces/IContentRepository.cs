using atteducation.api.Models;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface IContentRepository
    {
        Task<List<Content>> getContent();
        Task<Content> getContentById(int contetnId);
    } 
}