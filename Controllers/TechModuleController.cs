using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto.TechModulesDto;
using api.techunsolved.com.Repository.TechModuleRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechModuleController : ControllerBase
    {
        private readonly ITechModuleRepository _techModuleRepository;
        private readonly IMapper _mapper;
        public TechModuleController(ITechModuleRepository techModuleRepository, IMapper mapper)
        {
            _techModuleRepository = techModuleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "GetAllModules")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechModuleDto>>> GetAllModulesAsync()
        {
            var mod = await _techModuleRepository.GetAllIncludeSubCategoryAsync();
            var modDto = _mapper.Map<List<GetAllTechModuleDto>>(mod);

            return Ok(modDto);
        }

        //[HttpGet("{id:int}", Name = "GetModulesById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<IEnumerable<GetAllTechModuleDto>>> GetModulesByIdAsync(int id)
        //{
        //    if (id == null)
        //        return BadRequest();

        //    var modules = await _techModuleRepository.GetAllIncludeSubCategoryAsync(id);

        //    if (modules == null)
        //        return NotFound($"The data with {id} was not found.");

        //    var modDto = _mapper.Map<List<GetAllTechModuleDto>>(modules);

        //    return Ok(modDto);
        //}

        [HttpGet("{Id:int}", Name = "GetModulesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechModuleDto>>> GetModulesBySubCatIdAsync(int Id)
        {
            if (Id == null)
                return BadRequest();

            var modules = await _techModuleRepository.GetModulesBySubCatIdAndModuleIdAsync(Id);

            if (modules == null)
                return NotFound($"The data with {Id} was not found.");

            var modDto = _mapper.Map<List<GetAllTechModuleDto>>(modules);

            return Ok(modDto);
        }

        [HttpGet]
        [Route("GetCount", Name = "GetAllModulesCountAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetAllModulesCountAsync()
        {
            var modules = await _techModuleRepository.GetAllModulesCount();

            if (modules == 0)
                return NotFound($"No Record Found.");

            return Ok(modules);
        }

        [HttpGet]
        [Route("GetCountBysubCatId", Name = "GetAllModulesCountBySubCatIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetAllModulesCountBySubCatIdAsync(int subCatId)
        {
            var modules = await _techModuleRepository.GetCountBySubCatId(subCatId);

            if (modules == 0)
                return NotFound($"No Record Found.");

            return Ok(modules);
        }

        [HttpGet]
        [Route("GetCountBysubCatName", Name = "GetAllModulesCountBySubCatNameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetAllModulesCountBySubCatNameAsync(string subCatName)
        {
            var modules = await _techModuleRepository.GetCountBySubCatName(subCatName);

            if (modules == 0)
                return NotFound($"No Record Found.");

            return Ok(modules);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechModuleDto>> CreateAsync([FromBody] CreateTechModuleDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechModules modDto = _mapper.Map<TechModules>(dto);
            var modAfterCreation = await _techModuleRepository.CreateAsync(modDto);

            dto.TechModulesId = modAfterCreation.TechModulesId;

            return CreatedAtRoute("GetAllModules", dto);
        }

        [HttpGet]
        [Route("initial", Name = "GetModulesByInitial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetModulesByInitialDto>>> GetModulesByInitialAsync(string initial)
        {
            if (string.IsNullOrEmpty(initial))
                return BadRequest();

            var modules = await _techModuleRepository.GetModulesByInitial(initial);

            if (modules == null)
                return NotFound($"Error Not Found.");

            var modulesDto = _mapper.Map<List<GetModulesByInitialDto>>(modules);

            return Ok(modulesDto);
        }

        [HttpGet(Name = "GetModuleCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> GetModulesCount(string name)
        {
            var modules = await _techModuleRepository.GetModulesByInitial(name);

            int modulesCount = modules.Count();

            return modulesCount;
        }

        [HttpGet("subCategory", Name = "GetModulesBySubCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechModuleDto>>> GetModulesBySubCategoryAsync(string subCategory)
        {
            if (string.IsNullOrEmpty(subCategory))
                return BadRequest();

            var modules = await _techModuleRepository.GetListAsync(x => x.TechSubCategories.TechSubcategoryName == subCategory);

            if (modules == null)
                return NotFound($"The data with Sub-Category {subCategory} was not Found.");

            var modDto = _mapper.Map<List<GetAllModulesBySubCategoryDto>>(modules);

            return Ok(modDto);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechModuleDto>> UpdateModulesAsync([FromBody]CreateTechModuleDto dto)
        {
            if (dto == null || dto.TechModulesId < 0)
                return BadRequest();

            var existingModule = await _techModuleRepository.GetAsync(x => x.TechModulesId == dto.TechModulesId);

            if (existingModule == null)
                return NotFound($"The Module with the ID {dto.TechModulesId} was not Found.");

            var moduleDto = _mapper.Map<TechModules>(dto);
            await _techModuleRepository.UpdateAsync(moduleDto);

            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteTechModuleAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteTechModuleAsync(int id)
        {
            if (id == null)
                return BadRequest();

            var module = await _techModuleRepository.GetAsync(x => x.TechModulesId == id);

            if (module == null)
                return NotFound();

            await _techModuleRepository.DeleteAsync(module);

            return Ok(true);
        }

    }
}
