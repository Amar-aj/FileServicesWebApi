using FileServicesClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServicesWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController(IFileUploadService fileUploadService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(DocEntity doc)
    {
        return Ok(await fileUploadService.SaveFileAsync(doc));
    }
}
