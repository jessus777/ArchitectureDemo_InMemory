using Application.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userValidate = new CreateUserCommandValidator();
            var resultValidate = await userValidate.ValidateAsync(command, cancellationToken);

            if (!resultValidate.IsValid)
            {
                List<string> errors = new();
                errors.AddRange(resultValidate.Errors.Select(error => error.ErrorMessage));
                return new Response<int> { Message = "errores", Errors = errors };
            }

            User user = _mapper.Map<User>(command);

            await _userRepositoryAsync.CreateAsync(user);
            return new Response<int>(user.Id) { Message = "se agrego correctamente", Succeded = true };
        }
    }
}
