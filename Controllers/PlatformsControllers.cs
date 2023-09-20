using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlatformsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            var platforms = await _unitOfWork.PlatformRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{Id}", Name = "GetPlatformById")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(Guid Id)
        {
            var platform = await _unitOfWork.PlatformRepository.GetAsync(Id);
            
            if (platform is null)
                return NotFound();

            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> Create(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            
            await _unitOfWork.PlatformRepository.AddAsync(platformModel);
            await _unitOfWork.CommitAsync();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}