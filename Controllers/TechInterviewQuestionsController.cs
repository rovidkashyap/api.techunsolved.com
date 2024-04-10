using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto.TechInterviewQuestionsDto;
using api.techunsolved.com.Repository.TechInterviewQuestionsRepository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace api.techunsolved.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechInterviewQuestionsController : ControllerBase
    {
        private readonly ITechInterviewQuestionsRepository _techInterviewQuestionsRepository;
        private readonly IMapper _mapper;
        public TechInterviewQuestionsController(ITechInterviewQuestionsRepository techInterviewQuestionsRepository, IMapper mapper)
        {
            _techInterviewQuestionsRepository = techInterviewQuestionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All", Name = "GetAllQuestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllInterviewQuestionsDto>>> GetAllQuestionsAsync()
        {
            var questions = await _techInterviewQuestionsRepository.GetAllQuestionsIncludeModulesName();
            var questionsDto = _mapper.Map<List<GetAllInterviewQuestionsDto>>(questions);

            return Ok(questionsDto);
        }

        [HttpGet]
        [Route("GetCountByModulesName", Name ="GetQuestionsCountByModulesName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetQuestionsCountByModulesName(string name)
        {
            var questions = await _techInterviewQuestionsRepository.GetQuestionsCountByModules(name);

            if (questions == 0)
                return NotFound("No Record Found.");

            return Ok(questions);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateInterviewQuestionsDto>> CreateAsync([FromBody] CreateInterviewQuestionsDto dto)
        {
            if (dto == null)
                return BadRequest();

            TechInterview_Questions questionsDto = _mapper.Map<TechInterview_Questions>(dto);
            var quesAfterCreation = await _techInterviewQuestionsRepository.CreateAsync(questionsDto);

            dto.QuestionId = quesAfterCreation.QuestionId;

            return CreatedAtRoute("GetAllQuestions", dto);
        }
    }
}
