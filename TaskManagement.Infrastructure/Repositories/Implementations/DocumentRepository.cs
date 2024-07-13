using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TaskManagementDbContext _context;

        public DocumentRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentDTO>> GetAllDocumentsAsync()
        {
            var documents = await _context.Documents
                .Include(d => d.ETask)
                .Select(d => DocumentToDTO(d))
                .ToListAsync();

            return documents;
        }

        public async Task<DocumentDTO> GetDocumentByIdAsync(int id)
        {
            var document = await _context.Documents
                .Include(d => d.ETask)
                .FirstOrDefaultAsync(d => d.Id == id);

            return DocumentToDTO(document);
        }

        public async Task<DocumentDTO> CreateDocumentAsync(DocumentDTO documentDTO)
        {
            var document = new Document
            {
                FileName = documentDTO.FileName,
                FilePath = documentDTO.FilePath,
                TaskId = documentDTO.TaskId
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return DocumentToDTO(document);
        }

        public async Task<DocumentDTO> UpdateDocumentAsync(int id, DocumentDTO documentDTO)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id);

            if (document == null)
                throw new Exception($"Document with id {id} not found");

            document.FileName = documentDTO.FileName;
            document.FilePath = documentDTO.FilePath;
            document.TaskId = documentDTO.TaskId;

            await _context.SaveChangesAsync();

            return DocumentToDTO(document);
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id);

            if (document == null)
                return false;

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return true;
        }

        private static DocumentDTO DocumentToDTO(Document document) =>
            new DocumentDTO
            {
                Id = document.Id,
                FileName = document.FileName,
                FilePath = document.FilePath,
                TaskId = document.TaskId,
                ETask = TaskRepository.TaskToDTO(document.ETask)
            };
    }
}
