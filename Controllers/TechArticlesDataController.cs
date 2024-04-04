using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto.TechArticleDto;
using api.techunsolved.com.Models.Dto.TechArticlesDataDto;
using api.techunsolved.com.Repository.TechArticlesDataRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechArticlesDataController : ControllerBase
    {
        private readonly ITechArticlesDataRepository _techArticleDataRepository;
        private readonly IMapper _mapper;
        public TechArticlesDataController(ITechArticlesDataRepository techArticlesDataRepository, IMapper mapper)
        {
            _techArticleDataRepository = techArticlesDataRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        [Route("GetAllWithArticles", Name = "GetAllArticlesDataWithArticles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechArticlesDataDto>>> GetAllArticlesDataWithArticlesAsync()
        {
            var articlesData = await _techArticleDataRepository.GetAllIncludeTechArticles();

            if (articlesData == null)
                return BadRequest();

            var articlesDataDto = _mapper.Map<List<GetAllTechArticlesDataDto>>(articlesData);

            return Ok(articlesDataDto);
        }

        [HttpGet("{id:int}", Name = "GetArticlesDataById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechArticlesDataDto>>> GetArticlesDataByIdAsync(int id)
        {
            if (id == null)
                return BadRequest();

            var articlesDataById = await _techArticleDataRepository.GetDataIncludeTechArticlesById(id);

            if (articlesDataById == null)
                return NotFound($"The ID {id} was not found.");

            var articlesByIdDto = _mapper.Map<List<GetAllTechArticlesDataDto>>(articlesDataById);

            return Ok(articlesByIdDto);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechArticlesDataDto>> CreateAsync([FromBody] CreateTechArticlesDataDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechArticlesData articleDataDto = _mapper.Map<TechArticlesData>(dto);

            var articleafterCreation = await _techArticleDataRepository.CreateAsync(articleDataDto);

            dto.TechArticlesDataId = articleafterCreation.TechArticlesDataId;

            return CreatedAtRoute("GetAllArticles", dto);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechArticlesDataDto>> UpdateAsync([FromBody]CreateTechArticlesDataDto dto)
        {
            if (dto == null || dto.TechArticlesDataId < 0)
                return BadRequest();

            var existingArticleData = await _techArticleDataRepository.GetAsync(x => x.TechArticlesDataId == dto.TechArticlesDataId);

            if (existingArticleData == null)
                return NotFound($"The Articledata with {dto.TechArticlesDataId} was not Found.");

            var updateDto = _mapper.Map<TechArticlesData>(dto);
            var articleData = await _techArticleDataRepository.UpdateAsync(updateDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            if (id == null)
                return BadRequest();

            TechArticlesData articleData = await _techArticleDataRepository.GetAsync(x => x.TechArticlesDataId == id);

            if (articleData == null)
                return NotFound($"The ID {id} was not Found.");

            await _techArticleDataRepository.DeleteAsync(articleData);

            return Ok(true);

        }
    }
}
