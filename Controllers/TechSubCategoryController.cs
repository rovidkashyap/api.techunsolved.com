using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto;
using api.techunsolved.com.Repository.TechSubCategoryRepository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSubCategoryController : ControllerBase
    {
        private readonly ITechSubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public TechSubCategoryController(ITechSubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "GetAllSubCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TechSubCategoryDto>>> GetSubCategoriesAsync()
        {
            var subCat = await _subCategoryRepository.GetAllIncludeTechCategoryAsync();
            var catDto = _mapper.Map<List<TechSubCategoryDto>>(subCat);

            return Ok(catDto);
        }

        [HttpGet]
        [Route("GetBySubCategoryInitial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetSubCategoryByIdDto>>> GetByTechSubCategoryInitialAsync(string initial)
        {
            if (string.IsNullOrEmpty(initial))
                return BadRequest();

            var subCat = await _subCategoryRepository.GetByTechSubcategoryInitialAsync(initial);

            if (subCat == null)
                return NotFound($"The data with {initial} Initial was not found.");

            var subCatDto = _mapper.Map<List<GetSubCategoryByIdDto>>(subCat);
            return Ok(subCatDto);

        }

        [HttpGet("{Id:int}", Name = "GetByCategoryId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TechSubCategoryDto>>> GetSubCategoryByCatIdorSubCatIdAsync(int Id)
        {
            if (Id == null)
                return BadRequest();

            var subCat = await _subCategoryRepository.GetSubCategoryByIdAsync(Id);
            if (subCat == null)
                return NotFound();

            var subCatDto = _mapper.Map<List<TechSubCategoryDto>>(subCat);

            return Ok(subCatDto);
        }

        [HttpGet("{categoryNameOrInitial}", Name = "GetSubCategoryByCategoryName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetSubCategoryByCategoryNameDto>>> GetSubCategoryByCategoryName(string categoryNameOrInitial)
        {
            if (string.IsNullOrEmpty(categoryNameOrInitial))
                return BadRequest();

            var subCat = await _subCategoryRepository.GetListAsync(x => x.TechCategory.TechCategoryName == categoryNameOrInitial || x.TechCategory.Initial == categoryNameOrInitial);

            if (string.IsNullOrEmpty(subCat.ToString()))
                return NotFound($"Cannot found name {categoryNameOrInitial} in the records.");

            var subCatDto = _mapper.Map<List<GetSubCategoryByCategoryNameDto>>(subCat);

            return Ok(subCatDto);
        }

        [HttpGet(Name = "GetSubCategoryCount" )]
        public async Task<int> GetSubCategoryCount(string name)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryCount(name);

            return subCategory;
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateSubCategoryDto>> UpdateSubCategoryAsync([FromBody]UpdateSubCategoryDto dto)
        {
            if (dto == null || dto.TechSubcategoryId < 0)
                return BadRequest();

            var existingSubCategory = await _subCategoryRepository.GetAsync(subCategory => subCategory.TechSubcategoryId == dto.TechSubcategoryId);

            if (existingSubCategory == null)
                return NotFound();

            var newSubCategory = _mapper.Map<TechSubcategory>(dto);
            await _subCategoryRepository.UpdateAsync(newSubCategory);

            return NoContent();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateSubCategoryDto>> CreateSubCategoryAsync([FromBody]CreateSubCategoryDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechSubcategory subCat = _mapper.Map<TechSubcategory>(dto);
            var subCatAfterCreation = await _subCategoryRepository.CreateAsync(subCat);

            dto.TechSubcategoryId = subCatAfterCreation.TechSubcategoryId;

            return CreatedAtRoute("GetAllSubCategory", dto);
        }

        [HttpDelete("{id:int}", Name = "DeleteSubCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteSubCategoryAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var subCat = await _subCategoryRepository.GetAsync(x => x.TechSubcategoryId == id);

            if (subCat == null)
                return NotFound();

            await _subCategoryRepository.DeleteAsync(subCat);

            return Ok(true);
        }

    }
}
