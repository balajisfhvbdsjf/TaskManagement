using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> GetDocumentByIdAsync(int id);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> CreateDocumentAsync(Document document);
        Task<Document> UpdateDocumentAsync(int id, Document document);
        Task<bool> DeleteDocumentAsync(int id);
    }
}
