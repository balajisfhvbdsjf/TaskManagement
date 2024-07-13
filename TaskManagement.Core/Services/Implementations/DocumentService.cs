using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<DocumentDTO>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }

        public async Task<DocumentDTO> GetDocumentByIdAsync(int id)
        {
            return await _documentRepository.GetDocumentByIdAsync(id);
        }

        public async Task<DocumentDTO> CreateDocumentAsync(DocumentDTO documentDTO)
        {
            return await _documentRepository.CreateDocumentAsync(documentDTO);
        }

        public async Task<DocumentDTO> UpdateDocumentAsync(int id, DocumentDTO documentDTO)
        {
            return await _documentRepository.UpdateDocumentAsync(id, documentDTO);
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            return await _documentRepository.DeleteDocumentAsync(id);
        }
    }
}
