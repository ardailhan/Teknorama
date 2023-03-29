using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQueryRequest, MessageListDto>
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;

        public GetMessageQueryHandler(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessageListDto> Handle(GetMessageQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<MessageListDto>(data);
        }
    }
}
