namespace RestAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::RestAPI.Repository;
    using global::AutoMapper;

    namespace RestAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public abstract class BaseController<TEntity, TDto, TCreateDto> : ControllerBase
            where TEntity : class
        {
            protected readonly IRepository<TEntity> _repository;
            protected readonly IMapper _mapper;
            protected readonly ILogger _logger;

            protected BaseController(IRepository<TEntity> repository, IMapper mapper, ILogger logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;
            }

            // GET: api/[controller]
            [HttpGet]
            [Authorize(Roles = "profesor,administrador")]
            public async Task<IActionResult> GetAll()
            {
                try
                {
                    var entities = await _repository.GetAllAsync();
                    var dtos = _mapper.Map<List<TDto>>(entities);
                    return Ok(dtos);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener entidades");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            // GET: api/[controller]/{id}
            [HttpGet("{id:int}", Name = "[controller]_GetEntity")]
            [Authorize(Roles = "profesor,administrador")]
            public async Task<IActionResult> Get(int id)
            {
                try
                {
                    var entity = await _repository.GetAsync(id);
                    if (entity == null) return NotFound();

                    return Ok(_mapper.Map<TDto>(entity));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener la entidad con id {Id}", id);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            // POST: api/[controller]
            [HttpPost]
            [Authorize(Roles = "profesor,administrador")]
            public async Task<IActionResult> Create([FromBody] TCreateDto createDto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var entity = _mapper.Map<TEntity>(createDto);
                    await _repository.CreateAsync(entity);

                    var dto = _mapper.Map<TDto>(entity);
                    return CreatedAtRoute($"{ControllerContext.ActionDescriptor.ControllerName}_GetEntity", new { id = entity.GetHashCode() }, dto);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear entidad");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            // PUT: api/[controller]/{id}
            [HttpPut("{id:int}")]
            [Authorize(Roles = "profesor,administrador")]
            public async Task<IActionResult> Update(int id, [FromBody] TDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var entity = await _repository.GetAsync(id);
                    if (entity == null) return NotFound();

                    _mapper.Map(dto, entity);
                    await _repository.UpdateAsync(entity);

                    return Ok(_mapper.Map<TDto>(entity));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al actualizar entidad con id {Id}", id);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            // DELETE: api/[controller]/{id}
            [HttpDelete("{id:int}")]
            [Authorize(Roles = "profesor,administrador")]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    var entity = await _repository.GetAsync(id);
                    if (entity == null) return NotFound();

                    await _repository.DeleteAsync(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar entidad con id {Id}", id);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
        }
    }

}
