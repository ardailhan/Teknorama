using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQueryRequest, List<MessageListDto>>
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;

        public GetAllMessagesQueryHandler(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MessageListDto>> Handle(GetAllMessagesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<MessageListDto>>(data);
        }
    }
}
