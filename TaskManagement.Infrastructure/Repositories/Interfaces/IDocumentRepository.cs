using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentByIdAsync(int id);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> CreateDocumentAsync(Document document);
        Task<Document> UpdateDocumentAsync(int id, Document document);
        Task<bool> DeleteDocumentAsync(int id);
    }
}
