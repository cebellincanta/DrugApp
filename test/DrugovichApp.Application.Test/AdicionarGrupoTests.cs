
using AutoFixture;
using DrugovichApp.Application.GrupoCommand.Adicionar;
using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace DrugovichApp.Application.Test
{
    public  class AdicionarGrupoTests
    {
        private readonly Mock<IGrupoRepository> _repository;
        private readonly GrupoHandler _grupoHandler;
        private readonly Fixture _fixture;

        public AdicionarGrupoTests()
        {
            _repository = new Mock<IGrupoRepository>();
            _grupoHandler = new GrupoHandler(_repository.Object);
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


        }
        [Fact]
         public async Task AdicionarGrupo()
        {
            var grupofake = _fixture.Create<Grupo>();
            var gruporequestfake = _fixture.Create<GrupoRequest>();
            _repository.Setup(x => x.AddAsync(grupofake));
            var result = await _grupoHandler.Handle(gruporequestfake, It.IsAny<CancellationToken>());
            result.Should().BeOfType<GrupoDTO>();
        }
        
    }
}
