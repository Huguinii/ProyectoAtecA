using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.FranjaHorariaDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository;
using RestAPI.Repository.IRepository;
using System.Security.Claims;

namespace RestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FranjaHorariaController : BaseController<FranjaHorariaEntity, FranjaHorariaDTO, CreateFranjaHorariaDTO>
    {
        public FranjaHorariaController(IFranjaHorariaRepository franjaHorariaRepository,
            IMapper mapper, ILogger<FranjaHorariaController> logger)
            : base(franjaHorariaRepository, mapper, logger)
        {

        }
    }
}
