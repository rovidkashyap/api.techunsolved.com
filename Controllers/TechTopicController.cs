using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto.TechTopicDto;
using api.techunsolved.com.Repository.TechTopicRepository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechTopicController : ControllerBase
    {
        private readonly ITechTopicRepository _techTopicRepository;
        private readonly IMapper _mapper;

        public TechTopicController(ITechTopicRepository techTopicRepository, IMapper mapper)
        {
            _techTopicRepository = techTopicRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechTopicsDto>>> AllAsync()
        {
            var topics = await _techTopicRepository.GetAllIncludeModules();
            if (topics == null)
                return NotFound();

            var topicDto = _mapper.Map<List<GetAllTechTopicsDto>>(topics);

            return Ok(topicDto);
        }

        [HttpGet]
        [Route("GetAllTopics", Name = "GetAllTopics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechTopicsDto>>> GetAllAsync(int page = 1, int pageSize = 20)
        {
            var topics = await _techTopicRepository.GetAllIncludeTechModules(page, pageSize);

            if (topics == null)
                return NotFound();

            var topicsDto = _mapper.Map<List<GetAllTechTopicsDto>>(topics);

            return Ok(topicsDto);
        }

        [HttpGet("{Id:int}", Name = "GetTopicsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechTopicsDto>>> GetTopicsByModuleIdAsync(int Id)
        {
            if (Id == null)
                return BadRequest();

            var moduleDto = await _techTopicRepository.GetTopicsByModuleIdAndTopicIdAsync(Id);

            if (moduleDto == null)
                return NotFound($"The ID {Id} was not Found.");

            var topic = _mapper.Map<List<GetAllTechTopicsDto>>(moduleDto);

            return Ok(topic);
        }

        [HttpGet]
        [Route("{initial}", Name = "GetTopicsByInitial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTechTopicsWithInitialDto>>> GetTopicsByInitialAsync(string initial)
        {
            if (string.IsNullOrEmpty(initial))
                return BadRequest();

            var moduleDto = await _techTopicRepository.GetTopicsIncludeModulesByInitial(initial);

            if (moduleDto == null)
                return NotFound($"The Module Name {initial} was not Found.");

            var topic = _mapper.Map<List<GetAllTechTopicsWithInitialDto>>(moduleDto);

            return Ok(topic);
        }

        [HttpGet("count", Name = "GetTopicCounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTopicCount(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var moduleDto = await _techTopicRepository.GetTopicsIncludeModulesByInitial(name);

            if (moduleDto == null)
                return NotFound($"The Topic Name {name} was not Found.");

            int topic = moduleDto.Count();

            return Ok(topic);
        }

        [HttpGet("allCount", Name = "GetCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCount()
        {
            var allTopics = await _techTopicRepository.GetAllAsync();
            if (allTopics == null)
                return NotFound();

            int allTopicsCount = allTopics.Count();

            return Ok(allTopicsCount);
        }

        [HttpGet("{level}/{moduleName}", Name = "GetTopicsByLevel&Module")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTopicsByLevelDto>>> GetTopicsByLevelAsync(string level, string moduleName)
        {
            if (string.IsNullOrEmpty(level) && string.IsNullOrEmpty(moduleName))
                return BadRequest();

            var topicsDto = await _techTopicRepository.GetTopicsByLevelAndModuleId(level, moduleName);

            if (topicsDto == null)
                return NotFound($"The data was not Found.");

            var topic = _mapper.Map<List<GetAllTopicsByLevelDto>>(topicsDto);

            return Ok(topic);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechTopicDto>> CreateAsync([FromBody]CreateTechTopicDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechTopics topicDto = _mapper.Map<TechTopics>(dto);

            var topicafterCreation = await _techTopicRepository.CreateAsync(topicDto);

            dto.TechTopicId = topicafterCreation.TechTopicId;

            return CreatedAtRoute("GetAllTopics", dto);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTechTopicDto>> UpdateAsync([FromBody]CreateTechTopicDto dto)
        {
            if (dto == null | dto.TechTopicId < 0)
                return BadRequest();

            var existingTopic = await _techTopicRepository.GetAsync(x => x.TechTopicId == dto.TechTopicId);

            if (existingTopic == null)
                return NotFound($"The Topic with ID {dto.TechTopicId} was not Found.");

            var updateDto = _mapper.Map<TechTopics>(dto);
            var topic = await _techTopicRepository.UpdateAsync(updateDto);

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

            TechTopics topic = await _techTopicRepository.GetAsync(x => x.TechTopicId == id);

            if (topic == null)
                return NotFound($"The ID {id} was not Found.");

            await _techTopicRepository.DeleteAsync(topic);

            return Ok(true);
        }
    }
}
