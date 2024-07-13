using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDTO>> GetAllDocumentsAsync();
        Task<DocumentDTO> GetDocumentByIdAsync(int id);
        Task<DocumentDTO> CreateDocumentAsync(DocumentDTO documentDTO);
        Task<DocumentDTO> UpdateDocumentAsync(int id, DocumentDTO documentDTO);
        Task<bool> DeleteDocumentAsync(int id);
    }
}
