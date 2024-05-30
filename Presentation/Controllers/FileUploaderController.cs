using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Settings.Uploader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/uploader")]
    [ApiController]
    public class FileUploaderController : ControllerBase
    {
        private readonly IUploaderService _uploaderService;

        public FileUploaderController(IUploaderService uploaderService)
        {
            _uploaderService = uploaderService;
        }

        [HttpPost("file")]
        public async Task<IActionResult> UploadMeetingFile([FromForm] FileUploaderDto uploaderInfo,[FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not provided or empty.");
            }

            try
            {
                var uploader = new Uploader
                {
                    OrderFormId = uploaderInfo.OrderFormId,
                    UploaderId = uploaderInfo.UploaderId,
                };

                var fileId = await _uploaderService.UploadFileAsync(uploader, file);

                return Ok(fileId);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
