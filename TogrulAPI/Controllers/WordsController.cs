﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.Language;
using TogrulAPI.DTOs.Word;
using TogrulAPI.Exceptions;
using TogrulAPI.Services.Word.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostMany(IEnumerable<WordCreateDto> dto)
        {
            foreach (var item in dto)
            {
                await _service.CreateAsync(item);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                var words = await _service.GetByIdAsync(id);
                return Ok(words);
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id,WordUpdateDto dto)
        {
            var words = await _service.GetByIdAsync(id);
            if (words == null)
            {
                return NotFound();
            }
            words.Text = dto.Text;
            words.LanguageCode = dto.LanguageCode;

            var updateSuccess = await _service.UpdateAsync(id, dto);
            if (updateSuccess)
            {
                return Ok(words);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
