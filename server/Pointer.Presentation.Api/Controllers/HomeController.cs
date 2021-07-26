using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;
using SqlKata.Execution;

namespace Pointer.Presentation.Api.Controllers
{
    public class HomeController : BaseApiController
    {
        private readonly Repository<Skill> _skillRepository;

        private readonly Repository<Project> _projectRepository;

        private readonly Repository<User> _userRepository;

        private readonly Repository<Contact> _contactRepository;

        private readonly Repository<Configuration> _configurationRepository;

        public HomeController(Repository<Skill> skillRepository, Repository<Project> projectRepository, Repository<User> userRepository, Repository<Contact> contactRepository, Repository<Configuration> configurationRepository)
        {
            _skillRepository = skillRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _contactRepository = contactRepository;
            _configurationRepository = configurationRepository;
        }

        [ResponseCache(Duration = 120)]
        [HttpGet]
        public async Task<object> Get()
        {
            var skills = await _skillRepository.All();
            var latestProject = await _projectRepository.Query().OrderByDesc("Created").FirstOrDefaultAsync<Project>();
            var latestUpdatedProject = await _projectRepository.Query().OrderByDesc("Updated").FirstOrDefaultAsync<Project>();
            var description = await _configurationRepository.Query().Where("Key", "description").FirstOrDefaultAsync<Configuration>();
            return new
            {
                LatestProject = latestProject,
                LatestUpdatedProject = latestUpdatedProject,
                Skills = skills,
                Description = description?.Value ?? ""
            };
        }

        [HttpGet("dashboard")]
        public async Task<object> GetDashboard()
        {
            var projects = await _projectRepository.Query().CountAsync<int>();
            var skills = await _skillRepository.Query().CountAsync<int>();
            var contacts = await _contactRepository.Query().CountAsync<int>();
            var users = -1;
            var configurations = -1;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                users = await _userRepository.Query().CountAsync<int>();
                configurations = await _configurationRepository.Query().CountAsync<int>();
            }
            return new
            {
                Projects = projects,
                Skills = skills,
                Users = users,
                Contacts = contacts,
                Configurations = configurations
            };
        }
    }
}