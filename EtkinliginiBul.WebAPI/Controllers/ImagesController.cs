using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.Business.Validation.Images;
using EtkinliginiBul.DAL.Dtos.Images;
using Microsoft.AspNetCore.Mvc;

namespace EtkinliginiBul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesService _imagesService;
        public ImagesController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }
        [HttpGet("GetImagesList")]
        public async Task<ActionResult<List<GetListImagesDto>>> GetImagesList()
        {
            try
            {
                return Ok(await _imagesService.GetImagesList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetImagesById/{id}")]
        public async Task<ActionResult<GetImagesDto>> GetImagesById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _imagesService.GetImagesById(id);
                if (currentCountry == null)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    return currentCountry;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddImages")]
        public async Task<ActionResult<string>> AddImages(AddImagesDto addImagesDto)
        {
            var list = new List<string>();
            var validator = new ImagesAddValidator();
            var validationResults = validator.Validate(addImagesDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _imagesService.AddImages(addImagesDto);
                if (result > 0)
                {
                    list.Add("Kayıt Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Kayıt Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateImages/{id}")]
        public async Task<ActionResult<string>> UpdateImages(int id, UpdateImagesDto updateImagesDto)
        {
            var list = new List<string>();
            var validator = new ImagesUpdateValidator();
            var validationResults = validator.Validate(updateImagesDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _imagesService.UpdateImages(id, updateImagesDto);
                if (result > 0)
                {
                    list.Add("Güncelleme Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteImages/{id}")]
        public async Task<ActionResult<string>> DeleteImages(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _imagesService.DeleteImages(id);
                if (result > 0)
                {
                    list.Add("Silme işlemi başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
