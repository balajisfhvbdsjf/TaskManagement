using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDTO>> GetDocument(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        // POST: api/Documents
        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> PostDocument(DocumentDTO documentDTO)
        {
            var createdDocument = await _documentService.CreateDocumentAsync(documentDTO);
            return CreatedAtAction(nameof(GetDocument), new { id = createdDocument.Id }, createdDocument);
        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, DocumentDTO documentDTO)
        {
            if (id != documentDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedDocument = await _documentService.UpdateDocumentAsync(id, documentDTO);
                return Ok(updatedDocument);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var result = await _documentService.DeleteDocumentAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
