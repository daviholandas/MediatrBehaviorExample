using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrBehavior.Example.UseCases.Commands;

namespace MediatrBehavior.Example.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionalController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ProfessionalController(IMediator mediatR)
          => _mediatR = mediatR;

        [HttpPost]
        public IActionResult CreateProfessional(CreateProfessionalCommand command)
            => Ok(_mediatR.Send(command).Result);
    }
}
