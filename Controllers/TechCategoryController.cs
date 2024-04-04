using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto;
using api.techunsolved.com.Repository.TechCategoryRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechCategoryController : ControllerBase
    {
        private readonly ITechCategoryRepository _techCategoryRepository;
        private readonly IMapper _mapper;

        public TechCategoryController(ITechCategoryRepository techCategoryRepository, IMapper mapper)
        {
            _techCategoryRepository = techCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TechCategoryDto>>> GetCategoryAsync()
        {
            var cat = await _techCategoryRepository.GetAllAsync();
            var catDto = _mapper.Map<List<TechCategoryDto>>(cat);

            return Ok(catDto);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TechCategoryDto>> GetByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest();

            var data = await _techCategoryRepository.GetAsync(d => d.TechCategoryId == id);
            if (data == null)
                return NotFound($"The Category id {id} was not found.");

            var dataDto = _mapper.Map<TechCategoryDto>(data);

            return Ok(dataDto);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TechCategoryDto>> CreateAsync([FromBody]TechCategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            TechCategory category = _mapper.Map<TechCategory>(categoryDto);
            var catAfterCreation = await _techCategoryRepository.CreateAsync(category);

            categoryDto.TechCategoryId = catAfterCreation.TechCategoryId;

            return CreatedAtRoute("GetCategoryById", new { id = categoryDto.TechCategoryId }, categoryDto);
        }

        [HttpGet("{name}", Name = "GetCategoryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TechCategoryDto>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var cat = await _techCategoryRepository.GetAsync(cat => cat.TechCategoryName == name || cat.Initial == name);
            if (cat == null)
                return NotFound($"The Category with name {name} was not found.");

            var catDto = _mapper.Map<TechCategoryDto>(cat);

            return Ok(catDto);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TechCategoryDto>> UpdateCategoryAsync([FromBody]TechCategoryDto dto)
        {
            if (dto == null || dto.TechCategoryId > 0)
                BadRequest();

            var existingCategory = await _techCategoryRepository.GetAsync(x => x.TechCategoryId == dto.TechCategoryId);

            if (existingCategory == null)
                return NotFound();

            var newCategory = _mapper.Map<TechCategory>(dto);
            await _techCategoryRepository.UpdateAsync(newCategory);

            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteCategoryAsync(int id)
        {
            if (id <= null)
                return BadRequest();

            var category = await _techCategoryRepository.GetAsync(x => x.TechCategoryId == id);

            if (category == null)
                return NotFound();

            await _techCategoryRepository.DeleteAsync(category);

            return Ok(true);
        }
    }
}
