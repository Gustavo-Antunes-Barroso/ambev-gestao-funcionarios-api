using Ambev.GestaoFuncionarios.Application.Funcionarios.Create;
using Ambev.GestaoFuncionarios.Application.Funcionarios.Delete;
using Ambev.GestaoFuncionarios.Application.Funcionarios.Get;
using Ambev.GestaoFuncionarios.Application.Funcionarios.GetAll;
using Ambev.GestaoFuncionarios.Application.Funcionarios.Update;
using Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Create;
using Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Delete;
using Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Get;
using Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.GetAll;
using Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios.Update;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.GestaoFuncionarios.WebApi.Controllers.Funcionarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController(IMediator mediator, IMapper mapper) : Controller
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retorna todos os funcionários
        /// Aceita filtro para apenas gestores
        /// </summary>
        /// <param name="isGestor"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]bool? isGestor)
        {
            try
            {
                IEnumerable<GetAllFuncionarioResult> result = await _mediator.Send(new GetAllFuncionarioCommand(isGestor));
                IEnumerable<GetAllFuncionarioResponse> response = _mapper.Map<IEnumerable<GetAllFuncionarioResponse>>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um funcionário pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                GetFuncionarioRequestValidator validator = new GetFuncionarioRequestValidator();
                GetFuncionarioRequest request = new GetFuncionarioRequest(id);
                ValidationResult validations = await validator.ValidateAsync(request);

                if (!validations.IsValid)
                    return UnprocessableEntity(new { message = validations.Errors.Select(x => x.ErrorMessage) });

                GetFuncionarioCommand command = _mapper.Map<GetFuncionarioCommand>(request);
                GetFuncionarioResult result = await _mediator.Send(command);
                GetFuncionarioResponse response = _mapper.Map<GetFuncionarioResponse>(result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo funcionário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFuncionarioRequest request)
        {
            CreateFuncionarioRequestValidator validator = new CreateFuncionarioRequestValidator();
            ValidationResult validations = await validator.ValidateAsync(request);

            if (!validations.IsValid)
                return UnprocessableEntity(new{ message = validations.Errors.Select(x => x.ErrorMessage)});

            CreateFuncionarioCommand command = _mapper.Map<CreateFuncionarioCommand>(request);
            CreateFuncionarioResult result = await _mediator.Send(command);
            CreateFuncionarioResponse response = _mapper.Map<CreateFuncionarioResponse>(result);

            return Ok(response);
        }

        /// <summary>
        /// Edita um funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFuncionarioRequest request)
        {
            UpdateFuncionarioRequestValidator validator = new UpdateFuncionarioRequestValidator();
            ValidationResult validations = await validator.ValidateAsync(request);

            if (!validations.IsValid)
                return UnprocessableEntity(new { message = validations.Errors.Select(x => x.ErrorMessage) });

            UpdateFuncionarioCommand command = _mapper.Map<UpdateFuncionarioCommand>(request);
            UpdateFuncionarioResult result = await _mediator.Send(command);
            UpdateFuncionarioResponse response = _mapper.Map<UpdateFuncionarioResponse>(result);

            return Ok(response);
        }

        /// <summary>
        /// Deleta um funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteFuncionarioRequestValidator validator = new DeleteFuncionarioRequestValidator();
            DeleteFuncionarioRequest request = new DeleteFuncionarioRequest(id);
            ValidationResult validations = await validator.ValidateAsync(request);

            if (!validations.IsValid)
                return UnprocessableEntity(new { message = validations.Errors.Select(x => x.ErrorMessage) });

            DeleteFuncionarioCommand command = _mapper.Map<DeleteFuncionarioCommand>(new DeleteFuncionarioRequest(id));
            await _mediator.Send(command);
            return Ok(new { id, deleted = true });
        }
    }
}
