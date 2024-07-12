using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Core.Services.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _documentRepository.GetDocumentByIdAsync(id);
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }

        public async Task<Document> CreateDocumentAsync(Document document)
        {
            return await _documentRepository.CreateDocumentAsync(document);
        }

        public async Task<Document> UpdateDocumentAsync(int id, Document document)
        {
            return await _documentRepository.UpdateDocumentAsync(id, document);
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            return await _documentRepository.DeleteDocumentAsync(id);
        }
    }
}
