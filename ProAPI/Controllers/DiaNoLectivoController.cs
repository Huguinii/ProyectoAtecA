using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs;
using RestAPI.Models.Entity;
using RestAPI.Repository;
using RestAPI.Repository.IRepository;
using System.Security.Claims;

namespace RestAPI.Controllers
{
        
        [Route("api/[controller]")]
        [ApiController]
        public class DiaNoLectivoController : BaseController<DiaEntity, DiaDTO, CreateDiaDTO>
        {
            public DiaNoLectivoController(IDiaRepository diaRepository,
                IMapper mapper, ILogger<DiaNoLectivoController> logger)
                : base(diaRepository, mapper, logger)
            {

            }
        }
}
