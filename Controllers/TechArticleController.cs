using AutoMapper;
using AutoMapper.Configuration.Conventions;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto.TechArticleDto;
using api.techunsolved.com.Repository.TechArticleRepository.Class;
using api.techunsolved.com.Repository.TechArticleRepository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechArticleController : ControllerBase
    {
        private readonly ITechArticleRepository _techArticleRepository;
        private readonly IMapper _mapper;

        public TechArticleController(ITechArticleRepository techArticleRepository, IMapper mapper)
        {
            _techArticleRepository = techArticleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "GetAllArticles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllArticlesDto>>> GetAllArticlesAsync()
        {
            var articles = await _techArticleRepository.GetAllAsync();

            if (articles == null)
                return BadRequest();

            var articlesDto = _mapper.Map<List<GetAllArticlesDto>>(articles);

            return Ok(articlesDto);
        }

        [HttpGet]
        [Route("AllWithTopics", Name = "GetAllArticlesWithTopics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllArticlesWithTopicsDto>>> GetAllArticlesWithTopicsAsync()
        {
            var articles = await _techArticleRepository.GetAllIncludeTechTopics();

            if (articles == null)
                return BadRequest();

            var articlesDto = _mapper.Map<List<GetAllArticlesWithTopicsDto>>(articles);

            return Ok(articlesDto);
        }

        [HttpGet("{id:int}", Name = "GetArticlesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllArticlesWithTopicsDto>>> GetArticleByIdAsync(int id)
        {
            if (id == null)
                return BadRequest();

            var articlesById = await _techArticleRepository.GetListAsync(x => x.TechArticleId == id || x.techTopicId == id, article => article.techTopic);
            //var articlesById = await _techArticleRepository.GetListAsync(x => x.TechArticleId == id || x.techTopicId == id);
            //var articlesById = await _techArticleRepository.GetListAsync(x => x.techTopicId == id);

            if (articlesById == null)
                return NotFound($"The ID {id} was not Found.");

            var articlesByIdDto = _mapper.Map<List<GetAllArticlesWithTopicsDto>>(articlesById);

            return Ok(articlesByIdDto);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateArticleDto>> CreateAsync([FromBody]CreateArticleDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechArticles articleDto = _mapper.Map<TechArticles>(dto);

            var articleafterCreation = await _techArticleRepository.CreateAsync(articleDto);

            dto.techArticleId = articleafterCreation.TechArticleId;

            return CreatedAtRoute("GetAllArticles", dto);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateArticleDto>> UpdateAsync([FromBody]CreateArticleDto dto)
        {
            if (dto == null || dto.techArticleId < 0)
                return BadRequest();

            var existingArticle = await _techArticleRepository.GetAsync(x => x.TechArticleId == dto.techArticleId);

            if (existingArticle == null)
                return NotFound($"The Article with {dto.techArticleId} was not Found.");

            var updateDto = _mapper.Map<TechArticles>(dto);
            var article = await _techArticleRepository.UpdateAsync(updateDto);

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

            TechArticles article = await _techArticleRepository.GetAsync(x => x.TechArticleId == id);

            if (article == null)
                return NotFound($"The ID {id} was not Found.");

            await _techArticleRepository.DeleteAsync(article);

            return Ok(true);
        }
    }
}