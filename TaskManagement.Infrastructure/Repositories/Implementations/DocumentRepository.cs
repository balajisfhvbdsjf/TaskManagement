using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public DocumentRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _dbContext.Documents.FindAsync(id);
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _dbContext.Documents.ToListAsync();
        }

        public async Task<Document> CreateDocumentAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateDocumentAsync(int id, Document document)
        {
            _dbContext.Entry(document).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return document;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var document = await _dbContext.Documents.FindAsync(id);
            if (document == null)
                return false;

            _dbContext.Documents.Remove(document);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
