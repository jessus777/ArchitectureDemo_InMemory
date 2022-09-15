using Application.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, Response<IEnumerable<GetAllUserViewModel>>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;
        public GetAllUserHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllUserViewModel>>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepositoryAsync.GetAllAsync();

            if (users == default || !users.Any())
            {
                return new Response<IEnumerable<GetAllUserViewModel>>(null) { Message = "No hay Usuarios"};   
            }

            var userViewModels = _mapper.Map<IEnumerable<GetAllUserViewModel>> (users);

            return new Response<IEnumerable<GetAllUserViewModel>>(userViewModels) { Succeded = true, Message = $"Hay un total de {userViewModels.Count()} registros"};

        }
    }
}
